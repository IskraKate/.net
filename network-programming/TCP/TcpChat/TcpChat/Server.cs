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
            public string Name { get; set; }
        }

        private Socket _socketListener;
        private readonly List<Client> clientList = new List<Client>();


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
                clientList.Add(new Client { Socket = clientSocket, Name = "Sosiska" });

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

                string recievedString = Encoding.UTF8.GetString(_byteDataToReceive);
                logs.Invoke((MethodInvoker)(() => logs.Items.Add(recievedString)));

                clientSocket.BeginReceive(_byteDataToReceive, 0, _byteDataToReceive.Length, SocketFlags.None,
                            new AsyncCallback(OnReceive), clientSocket);

                byte[] byteDataToSend = Encoding.UTF8.GetBytes(recievedString);

                for(int i = 0; i < clientList.Count; i++)
                {
                    if (clientList[i].Socket != clientSocket)
                    {
                        clientList[i].Socket.BeginSend(byteDataToSend, 0, byteDataToSend.Length, SocketFlags.None,
                            new AsyncCallback(OnSend), clientList[i].Socket);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.Items.Add(ex.Message);
            }
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
