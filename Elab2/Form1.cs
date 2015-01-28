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
    enum Verbs
    {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    enum Options
    {
        SGA = 3
    }

    class TelnetConnection
    {
        TcpClient tcpSocket;

        int TimeOutMs = 100;

        public TelnetConnection(string Hostname, int Port)
        {
            tcpSocket = new TcpClient(Hostname, Port);

        }

        public string Login(string Username, string Password, int LoginTimeOutMs)
        {
            int oldTimeOutMs = TimeOutMs;
            TimeOutMs = LoginTimeOutMs;
            string s = Read();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Failed to connect : no login prompt");
            WriteLine(Username);

            s += Read();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Failed to connect : no password prompt");
            WriteLine(Password);

            s += Read();
            TimeOutMs = oldTimeOutMs;
            return s;
        }

        public void WriteLine(string cmd)
        {
            Write(cmd + "\n");
        }

        public void Write(string cmd)
        {
            if (!tcpSocket.Connected) return;
            byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF", "\0xFF\0xFF"));
            tcpSocket.GetStream().Write(buf, 0, buf.Length);
        }

        public string Read()
        {
            if (!tcpSocket.Connected) return null;
            StringBuilder sb = new StringBuilder();
            do
            {
                ParseTelnet(sb);
                System.Threading.Thread.Sleep(TimeOutMs);
            } while (tcpSocket.Available > 0);
            return sb.ToString();
        }

        public bool IsConnected
        {
            get { return tcpSocket.Connected; }
        }

        void ParseTelnet(StringBuilder sb)
        {
            while (tcpSocket.Available > 0)
            {
                int input = tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = tcpSocket.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC:
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppres go ahead)
                                int inputoption = tcpSocket.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                tcpSocket.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA)
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                                else
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                                tcpSocket.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }
    }

    public partial class Form1 : Form
    {
        Socket _socket = null;

        public Form1()
        {
            InitializeComponent();

            GetSerialPorts();
        }

        private void GetSerialPorts()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            ArrayComPortsNames = SerialPort.GetPortNames();

            do {
                index += 1;
                PortComboBox.Items.Add(ArrayComPortsNames[index]);
            } while (!((ArrayComPortsNames[index] == ComPortName) ||
                       (index == ArrayComPortsNames.GetUpperBound(0))));

            Array.Sort(ArrayComPortsNames);

            //want to get first out
            if (index == ArrayComPortsNames.GetUpperBound(0))
            {
                ComPortName = ArrayComPortsNames[0];
            }
            PortComboBox.Text = ArrayComPortsNames[0];
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (_socket == null)
            {
                try
                {
                    _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    _socket.Bind(new IPEndPoint(IPAddress.Any, 23));
                    ConnectButton.Text = "Disconnect";
                    LEDcheckBox.Checked = true;
                    LEDcheckBox.Invalidate();
                    SendCommand("B1\r");
                }
                catch (Exception ex)
                {
                    _socket = null;
                    ConnectButton.Text = "Connect";
                    System.Console.WriteLine(ex.Message);
                    string error_text = "Unable to open socket";
                    MessageBox.Show(error_text);
                }
            }
            else
            {
                _socket.Close();
                _socket = null;
                ConnectButton.Text = "Connect";
                LEDcheckBox.Checked = false;
                LEDcheckBox.Invalidate();
            }
        }

        delegate void SetTextCallback(string text);

        private void AnalogValText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.AnalogVal.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AnalogValText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.AnalogVal.Text = text;
            }
        }

        private void DataReceivedParser(string message)
        {
            char ch = message[0];
            string param = message.Substring(1);
            int numval = 0;
            try
            {   numval = Convert.ToInt16(param);}
            catch (FormatException e)
            { numval = 0; }
            catch (OverflowException e)
            { numval = 65535; }

            switch (Char.ToUpper(ch))
            {
                case 'A':
                    AnalogValText(numval.ToString());
                    break;
                case 'B':
                    break;
            }
        }

        string Arduino_reply;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serial_port = (SerialPort)sender;
            string indata = serial_port.ReadExisting();
            foreach (char ch in indata)
            {
                if (ch=='\r'||ch=='\n')
                {
                    if (Arduino_reply.Length>0)
                    {
                        DataReceivedParser(Arduino_reply);
                        Console.WriteLine(Arduino_reply);
                        Arduino_reply = String.Empty;
                        break;
                    }
                }
                else
                {
                    Arduino_reply += ch;
                }
            }
        }

        void SendCommand(string text)
        {
            if (_socket != null)
            {
//                _socket.Send(text);
            }
        }

        private void AnalogRead_Click(object sender, EventArgs e)
        {
            SendCommand("A\r");
        }

        private void LEDcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LEDcheckBox.Checked)
                SendCommand("B1\r");
            else
                SendCommand("B0\r");
        }
    }
}
