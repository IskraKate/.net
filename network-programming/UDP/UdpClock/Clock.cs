using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UdpClock
{
    public partial class ClockForm : Form
    {
        private static IPAddress _remoteAddress;
        private int _localPort;

        private UdpClient _receiver;

        public ClockForm()
        {
            InitializeComponent();

            _localPort = 8002;

            try
            {
                _remoteAddress = IPAddress.Parse("235.5.5.11");
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_receiver != null)
            {
                _receiver.Close();
            }
        }
        private void ReceiveMessage()
        {
            _receiver = new UdpClient(_localPort);
            _receiver.JoinMulticastGroup(_remoteAddress, 20);
            IPEndPoint remoteIp = null;

            try
            {
                while (true)
                {
                    byte[] data = _receiver.Receive(ref remoteIp);
                    string timeMessage = Encoding.Unicode.GetString(data);
                    var splitedTime = timeMessage.Split(':');

                    hourLabel.Text = splitedTime[0];
                    minuteLabel.Text = splitedTime[1];
                    secondLabel.Text = splitedTime[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}