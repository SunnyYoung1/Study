using DestTop.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalTestService
{
    class Program
    {
        private static readonly ContainerManager Container = ContainerManager.GetInstance();
        static void Main(string[] args)
        {
            ConsoleHelper.hideConsole();
            Container.StartService();
            Console.ReadLine();
        }
    }
}
