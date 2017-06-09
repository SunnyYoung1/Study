using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DestTopService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        #region 允许服务与桌面交互（系统配置成不允许交互服务）
        ///// <summary>
        ///// 允许服务与桌面交互
        ///// </summary>
        ///// <param name="savedState"></param>
        //protected override void OnAfterInstall(IDictionary savedState)
        //{
        //    try
        //    {
        //        base.OnAfterInstall(savedState);
        //        System.Management.ManagementObject myService = new System.Management.ManagementObject(
        //            string.Format("Win32_Service.Name='{0}'", this.ProductInstaller.ServiceName));
        //        System.Management.ManagementBaseObject changeMethod = myService.GetMethodParameters("Change");
        //        changeMethod["DesktopInteract"] = true;
        //        System.Management.ManagementBaseObject OutParam = myService.InvokeMethod("Change", changeMethod, null);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //} 
        #endregion
    }
}
