using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DeskTopApp
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            InitSettings();
        }

        private void InitSettings()
        {
            this.AutoStartCheckBox.Checked = Settings.Instance.AutoStart.HasValue&& Settings.Instance.AutoStart.Value;
            this.SeverIpTextBox.Text = Settings.Instance.ServerIp??"";
            this.ServerPortTextBox.Text = Settings.Instance.ServerPort ?? "";
        }

        private void SettingSaveBtn_Click(object sender, EventArgs e)
        {
            Settings.Instance.AutoStart = this.AutoStartCheckBox.Checked;
            Settings.Instance.ServerIp = this.SeverIpTextBox.Text;
            Settings.Instance.ServerPort = this.ServerPortTextBox.Text;
            SetAutoRun(this.AutoStartCheckBox.Checked);
            this.Close();
        }

        private void SetAutoRun(bool isAutoRun)
        {
            string starupPath = Application.ExecutablePath;
            RegistryKey loca = Registry.LocalMachine;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            try
            {
                if (isAutoRun == false) run.SetValue("DestTopClient", false); //取消开机运行
                else run.SetValue("DestTopClient", starupPath); //设置开机运行
            }
            catch
            {
            }
            finally
            {
                if (loca != null)
                {
                    loca.Close();
                }
                if (run != null)
                {
                    run.Close();
                }
            }
        }
    }
}
