using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UpdClockServer
{
    public partial class ServerForm : Form
    {
        private static IPAddress _remoteAddress;
        private int _remotePort;
        private int _localPort;

        private UdpClient _receiver;
        private UdpClient _sender;

        public ServerForm()
        {
            InitializeComponent();

            _remotePort = 8001;
            _localPort = 8001;

            try
            {
                _remoteAddress = IPAddress.Parse("235.5.5.11");

                Thread sendThread = new Thread(new ThreadStart(SendMessage));
                sendThread.IsBackground = true;
                sendThread.Start();
            }
            catch(Exception ex)
            {
                listBoxLog.Invoke((MethodInvoker)(() => listBoxLog.Items.Add(ex.Message)));
            }
        }

        private void serverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_receiver != null)
            {
                _receiver.Close();
            }
            if(_sender != null)
            {
                _sender.Close();
            }
        }

        private void SendMessage()
        {
            listBoxLog.Invoke((MethodInvoker)(() => listBoxLog.Items.Add($"Server is listening on port {_localPort}")));

            _sender = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(_remoteAddress, _remotePort);
            try
            {
                while (true)
                {
                    string message = DateTime.Now.ToLongTimeString();
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    listBoxLog.Invoke((MethodInvoker)(() => listBoxLog.Items.Add($"Sending data: {message}")));
                    _sender.Send(data, data.Length, endPoint);

                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                listBoxLog.Invoke((MethodInvoker)(() => listBoxLog.Items.Add(ex.Message)));
            }
        }

        private string LocalIPAddress()
        {
            string localIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
    }
}
