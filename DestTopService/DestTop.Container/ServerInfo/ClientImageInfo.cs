using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using DestTop.Container.App_Code;

namespace DestTop.Container.ServerInfo
{
    public class ClientImageInfo
    {
        public static List<ClientImage> ClientImages=new List<ClientImage>();
    }

    public class ClientImage
    {
        private const string fileName = "clientImageInfo.xml";
        private string fullFileName = null;
        private object lockObj=new object();
        private XmlDocument document = new XmlDocument();

        public ClientImage(string directoryPath)
        {
            DirectoryPath = directoryPath;
            fullFileName = Path.Combine(directoryPath, fileName);
            document.Load(fullFileName);
            ClientImageInfo.ClientImages.Add(this);
        }

        public ClientImage(string clientIp, int year, int month, int day)
        {
            ClientIp = clientIp;
            Year = year;
            Month = month;
            Day = day;
            DirectoryPath = PathConfig.GetClientImageDirectory(clientIp, year, month, day);
            fullFileName = Path.Combine(DirectoryPath, fileName);
            document.Load(fullFileName);
            ClientImageInfo.ClientImages.Add(this);
        }

        public string ClientIp{ get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        private long latestIndex = 0;

        public long LatestIndex {
            get
            {
                if (latestIndex == 0)
                {
                    XmlNode node = document.SelectSingleNode("/Settings/Setting/LatestIndex");
                    if (node == null)
                    {
                        return 0;
                    }
                    latestIndex = long.Parse(node.InnerText);
                }
                return latestIndex;
            }
            set
            {
                latestIndex = value;
                XmlNode node = document.SelectSingleNode("/Settings/Setting/LatestIndex");
                if (node == null)
                {
                    return;
                }
                node.InnerText = value.ToString();
                document.Save(fullFileName);
            }
        }

        private long lastRecordIndex = 0;

        public long LastRecordIndex
        {
            get
            {
                if (lastRecordIndex == 0)
                {
                    XmlNode node = document.SelectSingleNode("/Settings/Setting/LastRecordIndex");
                    if (node == null)
                    {
                        return 0;
                    }
                    lastRecordIndex = long.Parse(node.InnerText);
                }
                return lastRecordIndex;
            }
            set
            {
                lastRecordIndex = value;
                XmlNode node = document.SelectSingleNode("/Settings/Setting/LastRecordIndex");
                if (node == null)
                {
                    return;
                }
                node.InnerText = value.ToString();
                document.Save(fullFileName);
            }
        }

        private DateTime lastRecordTime = DateTime.MinValue;
        public DateTime LastRecordTime
        {
            get
            {
                if (lastRecordTime == DateTime.MinValue)
                {
                    XmlNode node = document.SelectSingleNode("/Settings/Setting/LastRecordTime");
                    if (node == null)
                    {
                        return DateTime.MinValue;
                    }
                    lastRecordTime = DateTime.Parse(node.InnerText);
                }
                return lastRecordTime;
            }
            set
            {
                if (value == DateTime.MinValue)
                {
                    return;
                }
                lastRecordTime = value;
                XmlNode node = document.SelectSingleNode("/Settings/Setting/LastRecordTime");
                if (node == null)
                {
                    return;
                }
                node.InnerText = value.ToString();
                document.Save(fullFileName);
            }
        }

        public string DirectoryPath { get; set; }

        public long GetCurrentIndex()
        {
            lock (lockObj)
            {
                LatestIndex = LatestIndex + 1;
                return LatestIndex;
            }
        }

        public void SaveCurrentImage(Image image)
        {
            if (!Directory.Exists(DirectoryPath))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(DirectoryPath); //新建文件夹   
            }

            //保存图片
            var imageName = GetCurrentIndex() + ".jpg";
            image.Save(Path.Combine(DirectoryPath,imageName));
        }

        public void ToVideo()
        {
            string imageFormat = string.Format("{0}%d.jpg", DirectoryPath);
            var nowDate = DateTime.Now;
            string videoPath = Path.Combine(DirectoryPath, string.Format("{0}-{1}", LastRecordTime.ToString("yyyyMMddhhmmss"),nowDate.ToString("yyyyMMddhhmmss")));
            ImagesToVideo.MakeVideo(imageFormat, videoPath);
            LastRecordIndex = LatestIndex;
            LastRecordTime = nowDate;
        }
    }
}
