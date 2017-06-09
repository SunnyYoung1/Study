using DestTop.Container;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTopApp
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        private static readonly ContainerManager Container = ContainerManager.GetInstance();
        private void Client_Load(object sender, EventArgs e)
        {
            Container.StartService();
        }
    }
}
