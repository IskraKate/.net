using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTcp
{
    public partial class Chat : Form
    {
        private Socket _clientSocket { get; set; }
        private string _clientName { get; set; }

        private int _port = 8000;
        private string _server = "127.0.0.1";

        private readonly byte[] _byteDataToReceive = new byte[1024];

        public Chat()
        {
            InitializeComponent();
        }

        private void SendData(string data)
        {
            try
            {
                var bytesToSend = ParseSendStr(data);

                _clientSocket.BeginSend(bytesToSend, 0, bytesToSend.Length, SocketFlags.None,
                    new AsyncCallback(OnSend), null);
            }
            catch(Exception ex)
            {
                listBoxMsges.Invoke((MethodInvoker)(() => listBoxMsges.Items.Add(ex.Message)));
            }
        }

        public byte[] ParseSendStr(string data)
        {
            byte[] bytesToSend = new byte[1024];
            var textInBytes = Encoding.UTF8.GetBytes(data);

            bytesToSend = BitConverter.GetBytes(textInBytes.Length);
            Array.Resize(ref bytesToSend, bytesToSend.Length + textInBytes.Length);

            for (int i = 4, j = 0; i < bytesToSend.Length; i++, j++)
            {
                bytesToSend[i] = textInBytes[j];
            }

            return bytesToSend;
        }

        private void RecieveData()
        {
            try
            {
                _clientSocket.BeginReceive(_byteDataToReceive, 0, _byteDataToReceive.Length, SocketFlags.None,
                    new AsyncCallback(OnReceive), null);
            }
            catch(Exception ex)
            {
                listBoxMsges.Invoke((MethodInvoker)(() => listBoxMsges.Items.Add(ex.Message)));
            }
        }


        private void OnSend(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndSend(ar);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                listBoxMsges.Invoke((MethodInvoker)(() => listBoxMsges.Items.Add(ex.Message)));
            }
        }
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndReceive(ar);

                var bytesMessage = ParseRecieveStr();

                string message = Encoding.UTF8.GetString(bytesMessage);

                listBoxMsges.Invoke((MethodInvoker)(() => listBoxMsges.Items.Add(message)));

                _clientSocket.BeginReceive(_byteDataToReceive, 0, _byteDataToReceive.Length, SocketFlags.None,
                    new AsyncCallback(OnReceive), null);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                listBoxMsges.Invoke((MethodInvoker)(() => listBoxMsges.Items.Add(ex.Message)));
            }
        }

        public byte[] ParseRecieveStr()
        {
            var bytesLenght = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                bytesLenght[i] = _byteDataToReceive[i];
            }

            int bytesLengthInt = BitConverter.ToInt32(bytesLenght, 0);

            var bytesMessage = new byte[bytesLengthInt];

            for (int i = 0, j = 4; i < bytesLengthInt; i++, j++)
            {
                bytesMessage[i] = _byteDataToReceive[j];
            }

            return bytesMessage;
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.ShowDialog();

            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var ipAddress = IPAddress.Parse(_server);
            var ipEndPoint = new IPEndPoint(ipAddress, _port);
            _clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);
        }

        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                string message = $"User {_clientName} has connected";
                SendData(message);

                listBoxMsges.Invoke((MethodInvoker)(() => listBoxMsges.Items.Add(message)));

                RecieveData();
            }
            catch (Exception ex)
            {
                listBoxMsges.Invoke((MethodInvoker)(() => listBoxMsges.Items.Add(ex.Message)));
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = $"{_clientName}: {textBoxMsg.Text}";
            SendData(message);

            listBoxMsges.Items.Add(message);
            textBoxMsg.Clear();
        }

        private void textBoxMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonSend_Click(sender, new EventArgs());
                e.SuppressKeyPress = true;
            }
        }

        public void RecieveLogin(string login)
        {
            _clientName = login;
        }
    }
}
