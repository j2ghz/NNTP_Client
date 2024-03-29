﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace NNTP_Client
{
    public class Connection
    {
        /// <summary>
        ///     An object to be locked so that execute methods can't steal each other's reponses
        /// </summary>
        private readonly object executing = new object();

        private readonly StreamReader reader;
        private readonly StreamWriter writer;

        public Connection(string hostname, int port)
        {
            var tcp = new TcpClient(hostname, port);
            ns = tcp.GetStream();
            reader = new StreamReader(ns);
            writer = new StreamWriter(ns);
            lock (executing)
            {
                WelcomeMessage = Receive();
            }
        }

        public string WelcomeMessage { get; }
        public NetworkStream ns { get; }

        private string Receive()
        {
            return reader.ReadLine();
        }

        public string Execute(string command)
        {
            lock (executing)
            {
                writer.WriteLine(command);
                writer.Flush();
                return Receive();
            }
        }

        public IList<string> ExecuteMultiline(string command)
        {
            lock (executing)
            {
                writer.WriteLine(command);
                writer.Flush();
                var list = new List<string> {Receive()};
                if (!list.First().StartsWith("2")) return list;
                while (true)
                {
                    var line = Receive();
                    if (line == ".") break;
                    list.Add(line);
                }

                return list;
            }
        }
    }
}