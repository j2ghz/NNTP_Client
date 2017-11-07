using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Group = NNTP_Client.Models.Group;

namespace NNTP_Client
{
    public class Client
    {
        private readonly Connection conn;
        private readonly object groupLock = new object();

        public Client(string hostname, ushort port, string user, string pass)
        {
            conn = new Connection(hostname, port);
            Login(user, pass);
        }

        private void Login(string user, string pass)
        {
            ValidateResponse(conn.Execute($"AUTHINFO USER {user}"), "381");
            ValidateResponse(conn.Execute($"AUTHINFO PASS {pass}"), "281");
        }

        private static void ValidateResponse(string response)
        {
            if (!Regex.IsMatch(response, @"^[123]"))
                throw new UnexpectedCommandResponseException("Start with status code 1xx, 2xx or 3xx", response);
        }

        private static void ValidateResponse(string response, string expectedCode)
        {
            if (!response.StartsWith(expectedCode))
                throw new UnexpectedCommandResponseException($"Start with the {expectedCode} status code", response);
        }

        public IEnumerable<string> ListGroups()
        {
            var response = conn.ExecuteMultiline("list");
            ValidateResponse(response.First(), "215");
            var groups = response.Skip(1);
            foreach (var group in groups)
                yield return group.Substring(0, group.IndexOf(' ') + 1);
        }

        public Group ChangeGroup(string group)
        {
            var response = conn.Execute($"GROUP {group}");
            ValidateResponse(response, "211");
            return new Group(response);
        }

        public class UnexpectedCommandResponseException : Exception
        {
            public UnexpectedCommandResponseException(string expectation, string response) : base(
                $"Expected format: {expectation}\nResponse: {response}")
            {
            }

            public UnexpectedCommandResponseException(string expectation, string response, Exception inner) : base(
                $"Expected format: {expectation}\nResponse: {response}", inner)
            {
            }
        }
    }
}