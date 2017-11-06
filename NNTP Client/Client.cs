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
                throw new Exception($"The response was invalid: {response}");
        }

        private static void ValidateResponse(string response, string expectedCode)
        {
            if (!response.StartsWith(expectedCode))
                throw new Exception($"The response had unexpected status code: {expectedCode} is not {response}");
        }

        public IEnumerable<Group> ListGroups()
        {
            var response = conn.ExecuteMultiline("list");
            ValidateResponse(response.First(), "215");
            var groupStrings = response.Skip(1);
            foreach (var groupString in groupStrings)
                yield return new Group(groupString);
        }
    }
}