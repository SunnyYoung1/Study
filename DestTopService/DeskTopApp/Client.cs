using DestTop.Container;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTopApp
{
    public partial class Client : Form
    {
        private bool isStarted = false;

        public Client()
        {
            InitializeComponent();
            this.SizeChanged += Client_SizeChanged;
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;  //显示在系统任务栏
                this.WindowState = FormWindowState.Normal;  //还原窗体
            }
        }

        private void Client_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
            {
                this.ShowInTaskbar = false;  //不显示在系统任务栏
                notifyIcon.Visible = true;  //托盘图标可见
            }
        }

        private static readonly ContainerManager Container = ContainerManager.GetInstance();
        private void Client_Load(object sender, EventArgs e)
        {
            if (!CheckServerSettings())
            {
                MessageBox.Show("服务器Ip或端口没有设置");
                return;
            }
            Container.StartService(Settings.Instance.ServerIp, Settings.Instance.ServerPort);
            if (!Container.IsConnected)
            {
                SetConnectedInfo(false);
                return;
            }
            isStarted = true;
            this.StartBtn.Text = "停止";
            SetConnectedInfo(true);
        }

        private void SetConnectedInfo(bool isConnected)
        {
            if (!isConnected)
            {
                this.ConnectedInfoLabel.Text = "连接服务失败";
                this.ConnectedInfoLabel.Visible = true;
                this.ConnectedInfoLabel.ForeColor = Color.Red;
            }
            else
            {
                this.ConnectedInfoLabel.Visible = false;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!CheckServerSettings())
            {
                MessageBox.Show("服务器Ip或端口没有设置");
                return;
            }
            if (!isStarted)
            {
                Container.StartService(Settings.Instance.ServerIp, Settings.Instance.ServerPort);
                if (!Container.IsConnected)
                {
                    SetConnectedInfo(false);
                    return;
                }
                isStarted = true;
                this.StartBtn.Text = "停止";
                this.StartMenuItem.Text = "停止";
                SetConnectedInfo(true);
            }
            else
            {
                Container.StopService();
                isStarted = false;
                this.StartBtn.Text = "启动";
                this.StartMenuItem.Text = "启动";
            }
        }

        private void SettingBtn_Click(object sender, EventArgs e)
        {
            SettingForm settingForm=new SettingForm();
            settingForm.ShowDialog();
        }

        private bool CheckServerSettings()
        {
            return !string.IsNullOrWhiteSpace(Settings.Instance.ServerIp) && !string.IsNullOrWhiteSpace(Settings.Instance.ServerPort);
        }
        

        private void StartMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckServerSettings())
            {
                MessageBox.Show("服务器Ip或端口没有设置");
                return;
            }
            if (!isStarted)
            {
                Container.StartService(Settings.Instance.ServerIp, Settings.Instance.ServerPort);
                if (!Container.IsConnected)
                {
                    SetConnectedInfo(false);
                    return;
                }
                isStarted = true;
                this.StartBtn.Text = "停止";
                this.StartMenuItem.Text = "停止";
                SetConnectedInfo(true);
            }
            else
            {
                Container.StopService();
                isStarted = false;
                this.StartBtn.Text = "启动";
                this.StartMenuItem.Text = "启动";
            }
        }

        private void SettingMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Container.StopService();
            this.Close();
        }

        private void ShowFormMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;  //显示在系统任务栏
                this.WindowState = FormWindowState.Normal;  //还原窗体
            }
        }
    }
}
