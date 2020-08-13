using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TcpChat
{
    public partial class Server : Form
    {
        private struct Client
        {
            public Socket Socket { get; set; }
        }

        private Socket _socketListener;
        private readonly List<Client> _clientList = new List<Client>();


        private readonly byte[] _byteDataToReceive = new byte[1024];
        private static readonly Encoding _encoding = Encoding.UTF8;

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            try
            {
                _socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ipEndPoint = new IPEndPoint(IPAddress.Any, 8000);

                _socketListener.Bind(ipEndPoint);
                _socketListener.Listen(10);
                _socketListener.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (Exception ex)
            {
                logs.Items.Add(ex.Message);
            }
        }

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = _socketListener.EndAccept(ar);
                _clientList.Add(new Client { Socket = clientSocket });

                _socketListener.BeginAccept(new AsyncCallback(OnAccept), null);

                clientSocket.BeginReceive(_byteDataToReceive, 0, _byteDataToReceive.Length, SocketFlags.None,
                            new AsyncCallback(OnReceive), clientSocket);
            }
            catch (Exception ex)
            {
                logs.Items.Add(ex.Message);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndReceive(ar);

                var recievedString = ParseReceiveStr();

                logs.Invoke((MethodInvoker)(() => logs.Items.Add(recievedString)));

                clientSocket.BeginReceive(_byteDataToReceive, 0, _byteDataToReceive.Length, SocketFlags.None,
                            new AsyncCallback(OnReceive), clientSocket);


                var byteDataToSend = ParseSendStr(recievedString);

                for(int i = 0; i < _clientList.Count; i++)
                {
                    if (_clientList[i].Socket != clientSocket)
                    {
                        _clientList[i].Socket.BeginSend(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None,
                            new AsyncCallback(OnSend), _clientList[i].Socket);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.Items.Add(ex.Message);
            }
        }

        public string ParseReceiveStr()
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

            string recievedString = Encoding.UTF8.GetString(bytesMessage);

            return recievedString;
        }

        public byte[] ParseSendStr(string recievedString)
        {
            byte[] byteDataToSend = new byte[1024];
            byte[] textInBytes = Encoding.UTF8.GetBytes(recievedString);

            byteDataToSend = BitConverter.GetBytes(textInBytes.Length);
            Array.Resize(ref byteDataToSend, byteDataToSend.Length + textInBytes.Length);
            for (int i = 4, j = 0; i < byteDataToSend.Length; i++, j++)
            {
                byteDataToSend[i] = textInBytes[j];
            }

            return byteDataToSend;
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TcpChat.Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
