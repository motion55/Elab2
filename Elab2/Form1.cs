using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

using System.Net;
using System.Net.Sockets;

namespace Elab
{
    public partial class Form1 : Form
    {
        TcpClient tcpSocket = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (tcpSocket == null)
            {
                try
                {
                    tcpSocket = new TcpClient("192.168.0.123", 23);
                    ConnectButton.Text = "Disconnect";
                }
                catch (Exception ex)              {
                    ConnectButton.Text = "Connect";
                    System.Console.WriteLine(ex.Message);
                    string error_text = "Unable to open connection";
                    MessageBox.Show(error_text);
                }
            }
            else
            {
                tcpSocket.Close();
                tcpSocket = null;
                ConnectButton.Text = "Connect";
            }
        }

        void SendCommand(string text)
        {
            if (tcpSocket.Connected)
            {
                byte[] Buffer = Encoding.ASCII.GetBytes(text);
                Int32 Count = Encoding.ASCII.GetByteCount(text);
                tcpSocket.GetStream().WriteAsync(Buffer, 0, Count);
            }
        }

        private void W_Click(object sender, EventArgs e)
        {
            SendCommand("W\r");
        }

        private void S_Click(object sender, EventArgs e)
        {
            SendCommand("S\r");
        }
    }
}
