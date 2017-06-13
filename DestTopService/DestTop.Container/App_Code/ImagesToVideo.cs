using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestTop.Container.App_Code
{
    public class ImagesToVideo
    {
        public static string MakeVideo(string imageFormat,string videoPath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "ffmpeg.exe";
            startInfo.Arguments = string.Format("-f image2 -i  {0} -vcodec libx264 -r 25 -b 200k  {1}", imageFormat, videoPath);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            return null;
        }
    }
}
