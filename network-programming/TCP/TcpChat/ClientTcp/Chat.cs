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
                byte[] byteDataToSend = Encoding.UTF8.GetBytes(data);

                _clientSocket.BeginSend(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None,
                    new AsyncCallback(OnSend), null);
            }
            catch(Exception ex)
            {
                listBoxMsges.Invoke((MethodInvoker)(() => listBoxMsges.Items.Add(ex.Message)));
            }
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

                string message = Encoding.UTF8.GetString(_byteDataToReceive);
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
            }
        }

        public void RecieveLogin(string login)
        {
            _clientName = login;
        }



        //private void Chat_Load(object sender, EventArgs e)
        //{
        //    ClientName = "Kate";
        //    Text = ClientName;

        //    TcpClient client = null;
        //    try
        //    {
        //        client = new TcpClient(address, port);
        //        NetworkStream stream = client.GetStream();
        //        while (true)
        //        {
        //            Console.Write(ClientName + ": ");
        //            // ввод сообщения
        //            string message = Console.ReadLine();
        //            message = String.Format("{0}: {1}", ClientName, message);
        //            // преобразуем сообщение в массив байтов
        //            byte[] data = Encoding.Unicode.GetBytes(message);
        //            // отправка сообщения
        //            stream.Write(data, 0, data.Length);

        //            // получаем ответ
        //            data = new byte[64]; // буфер для получаемых данных
        //            StringBuilder builder = new StringBuilder();
        //            int bytes = 0;
        //            do
        //            {
        //                bytes = stream.Read(data, 0, data.Length);
        //                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //            }
        //            while (stream.DataAvailable);

        //            message = builder.ToString();
        //            Console.WriteLine("Сервер: {0}", message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        client.Close();
        //    }

        //}
    }
}
