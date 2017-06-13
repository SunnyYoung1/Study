using System.Xml;

namespace DeskTopApp
{
    public class Settings
    {
        private static object lockObj=new object();
        private static Settings instance = null;
        private const string settingsFile = "Settings.xml";
        private XmlDocument document=new XmlDocument();

        private Settings()
        {
            document.Load(settingsFile);
        }

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance=new Settings();
                        }
                    }
                }
                return instance;
            }
        }
        
        private string serverIp = null;
        public string ServerIp
        {
            get
            {
                if (serverIp == null)
                {
                    XmlNode node = document.SelectSingleNode("/Settings/Setting/ServerIp");
                    if (node == null)
                    {
                        return null;
                    }
                    serverIp = node.InnerText;
                }
                return serverIp;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                serverIp = value;
                XmlNode node = document.SelectSingleNode("/Settings/Setting/ServerIp");
                if (node == null)
                {
                    return;
                }
                node.InnerText = value;
                document.Save(settingsFile);
            }
        }

        private string serverPort = null;
        public string ServerPort
        {
            get
            {
                if (serverPort == null)
                {
                    XmlNode node = document.SelectSingleNode("/Settings/Setting/ServerPort");
                    if (node == null)
                    {
                        return null;
                    }
                    serverPort = node.InnerText;
                }
                return serverPort;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                serverPort = value;
                XmlNode node = document.SelectSingleNode("/Settings/Setting/ServerPort");
                if (node == null)
                {
                    return;
                }
                node.InnerText = value;
                document.Save(settingsFile);
            }
        }

        private bool? autoStart =null;
        public bool? AutoStart
        {
            get
            {
                if (autoStart == null)
                {
                    XmlNode node = document.SelectSingleNode("/Settings/Setting/AutoStart");
                    if (node == null)
                    {
                        return false;
                    }
                    autoStart = node.InnerText.Trim()=="1"|| node.InnerText.Trim().ToLower() == "true";
                }
                return autoStart;
            }
            set
            {
                if (value==null)
                {
                    return;
                }
                autoStart = value;
                XmlNode node = document.SelectSingleNode("/Settings/Setting/AutoStart");
                if (node == null)
                {
                    return;
                }
                node.InnerText = value.ToString();
                document.Save(settingsFile);
            }
        }


    }
}
