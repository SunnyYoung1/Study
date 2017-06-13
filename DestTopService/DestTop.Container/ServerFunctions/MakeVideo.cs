using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DestTop.Container.App_Code;
using DestTop.Container.ServerInfo;

namespace DestTop.Container.ServerFunctions
{
    public class MakeVideo
    {
        private static object lockObj = new object();
        private static MakeVideo instance = null;

        public static MakeVideo Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new MakeVideo();
                        }
                    }
                }
                return instance;
            }
        }

        private MakeVideo()
        {
        }

        private Timer timer = null;

        public void StartRecord()
        {
            if (timer == null)
            {
                timer = new Timer(TimerProc, null, 30, 300);
                return;
            }
            timer.Change(30, 300);
        }

        private void TimerProc(object state)
        {
            foreach (var clientImage in ClientImageInfo.ClientImages)
            {
                if (clientImage.LastRecordTime.AddHours(2) < DateTime.Now)
                {
                    clientImage.ToVideo();
                }
            }
        }
    }

}
