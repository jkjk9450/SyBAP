using System;
using Renci.SshNet;

namespace SyBAP.Domain.Models
{
    public class HDFS : Group
    {
        private SshClient client;
        public string password;

        public HDFS(string host, string username, string password)
        {
            client = new SshClient(host, username, password);
            this.password = password;
            //client.Connect();5
        }

        public void RunCommand(string command)
        {
            var result = client.RunCommand("echo -e '" + password + "\\n' | " + command);
            Console.WriteLine(result.Result);
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        public void ViewTableList()
        {
        }
    }
}