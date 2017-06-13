using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestTop.Container.App_Code
{
    public class PathConfig
    {
        public static string GetVideoPath(string clientIp,int year,int month,int day,int h)
        {
            return string.Format(@"{0}\ClientVideo\{1}\{2}\{3}\{4}\{5}.mp4", AppDomain.CurrentDomain.BaseDirectory, clientIp, year,month,day,h);
        }

        public static string GetClientImageDirectory(string clientIp, int year, int month, int day)
        {
            return string.Format(@"{0}\ClientImage\{1}\{2}\{3}\{4}\", AppDomain.CurrentDomain.BaseDirectory, clientIp, year, month, day);
        }
    }
}
