using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DestTop.Container
{
    public class CaptureScreen
    {
        public static Bitmap BySizeGetScreen(string remoteEndPoint, Image _image, int width, int height)
        {
            try
            {
                int thumbWidth = width;
                Image image = _image; //利用Image对象装载源图像
                Screen s = Screen.PrimaryScreen;
                Rectangle r = s.Bounds;
                int srcWidth = _image.Width;
                int srcHeight = _image.Height;
                int thumbHeight = height;
                Bitmap bmp = new Bitmap(width, height);
                Graphics gr = Graphics.FromImage(bmp);
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.InterpolationMode = InterpolationMode.High;
                Rectangle rectDestination = new Rectangle(0, 0, thumbWidth, thumbHeight);
                gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);

                //保存图片
                SaveImage(remoteEndPoint, bmp);
                return bmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 将指定的数组内容写入到 Image
        /// </summary>
        /// <param name="byteArray">指定的数组</param>
        /// <returns></returns>
        public static Image ToImage(byte[] byteArray)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArray);
                return Image.FromStream(ms);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void SaveImage(string remoteEndPoint, Bitmap bmp)
        {
            remoteEndPoint = remoteEndPoint.Substring(0, remoteEndPoint.IndexOf(":"));
            DateTime now = DateTime.Now;
            string path = AppDomain.CurrentDomain.BaseDirectory + "ClientImage\\" + remoteEndPoint + "\\" + now.Year.ToString() + "\\" + now.Month + "\\" + now.Day + "\\";
            CreateDirectory(path);

            //保存图片
            var imageName = GetTimeStamp() + ".jpg";
            string savePath = path + imageName;
            bmp.Save(savePath);
        }
        private static void CreateDirectory(string infoPath)
        {
            if (!Directory.Exists(infoPath))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(infoPath); //新建文件夹   
            }
        }
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

    }
}
