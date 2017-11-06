using System.IO;
using System.Net.Sockets;
using System.Text;

namespace NNTP_Client
{
    public class Connection
    {
        private readonly StreamReader reader;
        private readonly StreamWriter writer;

        public Connection(string hostname, int port)
        {
            var tcp = new TcpClient(hostname, port);
            ns = tcp.GetStream();
            reader = new StreamReader(ns);
            writer = new StreamWriter(ns);
            WelcomeMessage = Receive();
        }

        public string WelcomeMessage { get; }
        public NetworkStream ns { get; }

        public string Receive()
        {
            return reader.ReadLine();
        }

        public string Execute(string command, bool multiline = false)
        {
            writer.WriteLine(command);
            writer.Flush();

            if (!multiline)
                return Receive();

            var sb = new StringBuilder();
            string line;
            do
            {
                line = Receive();
                sb.AppendLine(line);
            } while (line != ".");
            return sb.ToString();
        }
    }
}