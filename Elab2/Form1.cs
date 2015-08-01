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
        Socket _socket = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (_socket == null)
            {
                try
                {
                    _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ConnectButton.Text = "Disconnect";
                }
                catch (Exception ex)              
                {
                    ConnectButton.Text = "Connect";
                    System.Console.WriteLine(ex.Message);
                    string error_text = "Unable to open connection";
                    MessageBox.Show(error_text);
                }
            }
            else
            {
                _socket.Close();
                _socket = null;
                ConnectButton.Text = "Connect";
            }
        }

        void SendCommand(string text)
        {
            if (_socket.Connected)
            {
                byte[] Buffer = Encoding.ASCII.GetBytes(text);
                Int32 Count = Encoding.ASCII.GetByteCount(text);
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
