using System;
using System.IO;

namespace DestTop.Container
{
    public class Log
    {
        private string logFile;
        private StreamWriter writer;
        private FileStream fileStream = null;
        private static object _sync = new object();

        public Log(string fileName)
        {
            logFile = fileName;
            CreateDirectory(logFile);
        }

        public void log(string info)
        {
            System.Threading.Monitor.Enter(_sync);
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(logFile);
                if (!fileInfo.Exists)
                {
                    fileStream = fileInfo.Create();
                    writer = new StreamWriter(fileStream);
                }
                else
                {
                    fileStream = fileInfo.Open(FileMode.Append, FileAccess.Write);
                    writer = new StreamWriter(fileStream);
                }
                writer.WriteLine(DateTime.Now + ": " + info);

            }
            catch
            {

            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                    fileStream.Close();
                    fileStream.Dispose();
                }
                System.Threading.Monitor.Exit(_sync);
            }
        }

        public void CreateDirectory(string infoPath)
        {
            DirectoryInfo directoryInfo = Directory.GetParent(infoPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
    }
}
