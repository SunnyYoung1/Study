using DestTop.Container;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DestTopService
{
    public partial class DestTopServices : ServiceBase
    {
        private readonly ContainerManager _containerManager = ContainerManager.GetInstance();
        private static readonly Log log = new Log(AppDomain.CurrentDomain.BaseDirectory + @"/log/Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        private string appName = AppDomain.CurrentDomain.BaseDirectory + @"/test/DeskTopApp.exe";
        protected override void OnStart(string[] args)
        {
            Thread thread = new Thread(() =>
            {
                //_containerManager.StartService();

                proc_Start();
            });
            thread.Start();

            //_containerManager.StopService();
        }
        private void proc_Start()
        {
            try
            {
                //启动外部程序
                Process proc = Process.Start(appName);
                log.log("启动外部程序");
                if (proc != null)
                {
                    //监视进程退出
                    proc.EnableRaisingEvents = true;
                    //指定退出事件方法
                    proc.Exited += new EventHandler(proc_Exited);
                }
            }
            catch (Exception ex)
            {
                log.log("启动外部程序出错:" + ex.Message);
            }
        }
        private void proc_Exited(object sender, EventArgs e)
        {
            proc_Start();
        }
        protected override void OnStop()
        {
            //_containerManager.StopService();
        }
    }
}
