using System.Net.Sockets;
using System.Net;

namespace ClientTest
{
    public class Client
    {
        private IPAddress _address => IPAddress.Parse(Service.IpStr);
        private Socket _clientSocket;
        public bool CheckConnected => _clientSocket.Connected;
        public Client() 
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

        }

        public void IsConnected()
        {
            _clientSocket.ConnectAsync(_address, Service.Port);

        }

        public async Task<string> GetMsgAsync() => Service.RecieveMsg(_clientSocket);


        public bool isIncorrectAnswer(string serverResp)
        {
            bool isCorrcet = serverResp == "f";

            Console.WriteLine(isCorrcet ? "Inccorect" : "Correct");

            return isCorrcet;
        }

        public void ReadMsg(string msg)
        {
            if (msg.Length <= 0)
            {
                return;
            }
            Service.SendMsg(_clientSocket, msg);
        }
    }
}