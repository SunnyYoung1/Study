using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DestTop.Container
{
    public class ContainerManager
    {
        private static ContainerManager _instance;
        private static readonly object ObjLock = new object();
        private IPEndPoint ServerInfo = null;
        private Socket ClientSocket;
        //信息发送存储
        private Byte[] MsgSend;

        private Log log = new Log(AppDomain.CurrentDomain.BaseDirectory + @"/log/Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");

        /// <summary>
        /// 获取容器管理器实例
        /// </summary>
        /// <returns></returns>
        public static ContainerManager GetInstance()
        {
            if (_instance == null)
            {
                lock (ObjLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ContainerManager();
                    }
                }
            }

            return _instance;
        }

        public bool IsConnected
        {
            get { return ClientSocket != null && ClientSocket.Connected; }
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        public void StartService()
        {
            MsgSend = new Byte[65535];
            Thread t = new Thread(Go)
            {
                IsBackground = true
            };
            t.Start();
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        public void StartService(string ip,string port)
        {
            ServerInfo = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));

            Connect();

            MsgSend = new Byte[65535];
            Thread t = new Thread(Go)
            {
                IsBackground = true
            };
            t.Start();
        }

        public void Connect()
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //服务端IP和端口信息设定,这里的IP可以是127.0.0.1，可以是本机局域网IP，也可以是本机网络IP
                ServerInfo = ServerInfo ?? new IPEndPoint(IPAddress.Parse("10.101.42.105"), Convert.ToInt32(316));
                ClientSocket.Connect(ServerInfo);//客户端连接服务端指定IP端口，Socket
            }
            catch (Exception e)
            {
                log.log("错误1：" + e.Message);
            }
        }

        public void Go()
        {
            try
            {
                lock (this)
                {
                    //ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ////服务端IP和端口信息设定,这里的IP可以是127.0.0.1，可以是本机局域网IP，也可以是本机网络IP
                    //ServerInfo = ServerInfo?? new IPEndPoint(IPAddress.Parse("10.101.42.105"), Convert.ToInt32(316));
                    //ClientSocket.Connect(ServerInfo);//客户端连接服务端指定IP端口，Socket

                    if (IsConnected)
                    {
                        int REnd = ClientSocket.Receive(MsgSend); //等待接收服务端发送的指令
                        string msg = Encoding.Unicode.GetString(MsgSend, 0, REnd);
                        if (msg == "Send")
                        {
                            MsgSend = new byte[65535];
                            MsgSend = new Monitor().GetDesktopBitmapBytes();
                            //MsgSend = Encoding.Unicode.GetBytes("图片" + imgIndex);
                            if (ClientSocket.Connected)
                            {
                                //将数据发送到连接的 System.Net.Sockets.Socket。
                                ClientSocket.Send(MsgSend);
                                ClientSocket.BeginSend(MsgSend, 0, MsgSend.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), ClientSocket);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.log("错误1："+ex.Message);
                CloseSocket();
                //Go();
            }
        }

        protected void ReceiveCallBack(IAsyncResult AR)
        {
            try
            {
                Socket listener = (Socket)AR.AsyncState;
                //将用户登录信息发送至服务器，由此可以让其他客户端获知
                //ClientSocket.Send(Encoding.Unicode.GetBytes("用户： " + IPAddress.Any + " 进入系统！\n"));
                MsgSend = new Monitor().GetDesktopBitmapBytes();
                if (listener.Connected)
                {
                    //将数据发送到连接的 System.Net.Sockets.Socket。
                    //ClientSocket.Send(MsgSend);
                    //AsyncCallback引用在异步操作完成时调用的回调方法
                    listener.BeginSend(MsgSend, 0, MsgSend.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), listener);
                }
            }
            catch (Exception ex)
            {
                log.log("错误2：" + ex.Message);
                CloseSocket();
                //Go();
            }
        }
        protected void CloseSocket()
        {
            if (ClientSocket.Connected)
            {
                //禁用发送和接受
                ClientSocket.Shutdown(SocketShutdown.Both);
                //关闭套接字，不允许重用
                ClientSocket.Disconnect(false);
                ClientSocket.Close();
            }
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        public void StopService()
        {
            if (ClientSocket != null)
                ClientSocket.Close();//关闭SOCKET
        }
    }
}
