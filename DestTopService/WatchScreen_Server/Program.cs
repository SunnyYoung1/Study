using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//  源码学习下载www.lvcode.com
//    欢迎分享源码给Love代码
namespace WatchScreen_Server
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WatchScreenForm());
        }
    }
}
