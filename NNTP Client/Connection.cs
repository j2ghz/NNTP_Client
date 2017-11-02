using System.Net.Sockets;

namespace NNTP_Client
{
    public class Connection
    {
        public Connection(string hostname, int port)
        {
            var tcp = new TcpClient(hostname, port);
            ns = tcp.GetStream();
        }

        public NetworkStream ns { get; }
    }
}