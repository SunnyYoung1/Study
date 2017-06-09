using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using DestTop.Container;

namespace WatchScreen_Server
{
    /// <summary>
    /// 整体页面风格 待调整 
    /// 客户端关闭时 从列表中移除
    /// </summary>
    public partial class WatchScreenForm : Form
    {
        private IPEndPoint ServerInfo;//存放服务器的IP和端口信息
        private Socket ServerSocket;//服务端运行的SOCKET
        private Thread ServerThread;//服务端运行的线程
        private Thread ClientAliveThread;//服务端运行的线程
        private Socket[] ClientSocket;//为客户端建立的SOCKET连接集合
        private int ClientNumb;//连接客户端的总数量
        private byte[] MsgBuffer;//存放消息数据
        private const int port = 316;//服务端 端口号
        private bool ThreadRun = true;//服务是否运行

        public WatchScreenForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            string strHostName = Dns.GetHostName(); //得到本机的主机名 
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName); //取得本机IP       
            lbLocalIp.Text = ipEntry.AddressList[1].ToString() + ":" + port;
        }

        private void btnHandleService_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnHandleService.Text == "启动服务...")
                {
                    ThreadRun = true;
                    ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //提供一个 IP 地址，指示服务器应侦听所有网络接口上的客户端活动
                    IPAddress ip = IPAddress.Any;
                    ServerInfo = new IPEndPoint(ip, port);
                    ServerSocket.Bind(ServerInfo);//将SOCKET接口和IP端口绑定
                    ServerSocket.Listen(10);//开始监听，并且挂起数为10
                    MsgBuffer = new byte[65535];
                    ClientSocket = ClientSocket ?? (new Socket[65535]);//为客户端提供连接个数
                    ClientNumb = 0;//数量从0开始统计

                    ServerThread = new Thread(new ThreadStart(RecieveAccept));//将接受客户端连接的方法委托给线程
                    ServerThread.Start();//线程开始运行

                    CheckForIllegalCrossThreadCalls = false;//不捕获对错误线程的调用

                    btnHandleService.Text = "停止服务...";
                    lbStatus.Text = "已启动服务";

                    //起一个线程 判断客户端是否已断开连接
                    ClientAliveThread = new Thread(new ThreadStart(CheckClientIsAlive));//将接受客户端连接的方法委托给线程
                    ClientAliveThread.Start();//线程开始运行
                }
                else if (btnHandleService.Text == "停止服务...")
                {
                    ThreadRun = false;
                    ServerThread.Abort();//线程终止
                    ServerSocket.Close();//关闭socket
                    btnHandleService.Text = "启动服务...";
                    lbStatus.Text = "已停止服务";
                }
            }
            catch (Exception ex)
            {
                ThreadRun = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void WatchScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadRun = false;
            Application.Exit();
        }

        private void lbClientIps_MouseMove(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            ListViewItem oldItem = null;
            if (listView.Tag != null) oldItem = (ListViewItem)listView.Tag;

            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                if (oldItem != null && !oldItem.Equals(item)) oldItem.BackColor = listView.BackColor;
                item.BackColor = Color.CornflowerBlue;
                listView.Tag = item;
            }
            else
            {
                if (oldItem != null && !oldItem.BackColor.Equals(listView.BackColor)) oldItem.BackColor = listView.BackColor;
            }
        }

        private void tsmiWatchInTime_Click(object sender, EventArgs e)
        {
            ShowClientScreen();
        }

        private void tsmiWatchHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developing...");
        }

        private void lbClientIps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowClientScreen();
        }

        public void ShowClientScreen()
        {
            try
            {
                if (lbClientIps.SelectedItems.Count > 0)
                {
                    Thread.Sleep(350);
                    int selIndex = lbClientIps.SelectedItems[0].ImageIndex;
                    MsgBuffer = Encoding.Unicode.GetBytes("Send");
                    ClientSocket[selIndex].Send(MsgBuffer);
                    ClientSocket[selIndex].BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallBack), ClientSocket[selIndex]);
                }
            }
            catch (Exception ex)
            {
                ThreadRun = false;
                MessageBox.Show(ex.Message);
            }
        }


        //检查客户端是否还活着
        private void CheckClientIsAlive()
        {

            while (ThreadRun)
            {
                Thread.Sleep(1000);
                int selIndex = lbClientIps.SelectedItems.Count > 0 ? lbClientIps.SelectedItems[0].ImageIndex : -1;
                try
                {
                    if (selIndex > -1)
                    {
                        ClientSocket[selIndex].Send(Encoding.Unicode.GetBytes("Send"));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("客户端： " + ClientSocket[selIndex].RemoteEndPoint.ToString()+"  已断开连接");
                    var clientList= ClientSocket.ToList();
                    clientList.RemoveAt(selIndex);
                    ClientSocket = clientList.ToArray();
                    lbClientIps.Items.RemoveAt(selIndex);
                    pbScreen.Image = null;
                    ClientNumb--;
                    ThreadRun = false;
                    return;
                }
            }
        }

        //接受客户端连接的方法
        private void RecieveAccept()
        {
            while (ThreadRun)
            {
                //Accept 以同步方式从侦听套接字的连接请求队列中提取第一个挂起的连接请求，然后创建并返回新的 Socket。
                //在阻止模式中，Accept 将一直处于阻止状态，直到传入的连接尝试排入队列。连接被接受后，原来的 Socket 继续将传入的连接请求排入队列，直到您关闭它。
                ClientSocket[ClientNumb] = ServerSocket.Accept();
                
                lock (lbClientIps)
                {
                    if (ClientSocket[ClientNumb] == null) return;
                    string title = ClientSocket[ClientNumb].RemoteEndPoint.ToString();
                    lbClientIps.Items.Add(title, title, ClientNumb);

                    //客户端上线时  模拟渐变效果 待优化
                    lbClientIps.Items[ClientNumb].BackColor = Color.Red;
                    Thread.Sleep(300);
                    lbClientIps.Items[ClientNumb].BackColor = Color.Green;
                    Thread.Sleep(300);
                    lbClientIps.Items[ClientNumb].BackColor = Color.Pink;
                    Thread.Sleep(300);
                    lbClientIps.Items[ClientNumb].BackColor = Color.CornflowerBlue;

                    //MsgBuffer = Encoding.Unicode.GetBytes("Send");
                    //ClientSocket[ClientNumb].Send(MsgBuffer);
                    //ClientSocket[ClientNumb].BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallBack), ClientSocket[ClientNumb]);
                }
                ClientNumb++;
                
            }
        }

        

        //回发数据给客户端
        private void RecieveCallBack(IAsyncResult AR)
        {
            try
            {
                if (!ThreadRun)
                {
                    return;
                }

                int selIndex = lbClientIps.SelectedItems[0].ImageIndex;
                MsgBuffer = new byte[1048576];
                int number = ClientSocket[selIndex].Receive(MsgBuffer);
                Image img = CaptureScreen.ToImage(MsgBuffer);
                string title = ClientSocket[selIndex].RemoteEndPoint.ToString();
                img = CaptureScreen.BySizeGetScreen(title,img, pbScreen.Width, pbScreen.Height);
                if (img != null)
                {
                    pbScreen.Image = img;
                }
                ClientSocket[selIndex].BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallBack), ClientSocket[selIndex]);

            }
            catch (Exception ex)
            {
                //lbClientIps.Items.RemoveAt(0);
                //pbScreen.Image = null;  
            }
            finally
            {

            }
        }

    }
}
