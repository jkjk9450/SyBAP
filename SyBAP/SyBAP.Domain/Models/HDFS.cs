using Renci.SshNet;
using System;

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
            client.Connect();
            Console.WriteLine("Server Connected");
        }

        public void RunCommand(string command)
        {
            var result = client.RunCommand(command);
            Console.WriteLine(result.CommandText);
            Console.WriteLine(result.Result);
        }

        public void RunSudoCommand(string command)
        {
            var result = client.RunCommand("echo -e '" + password + "\\n' | sudo -S " + command);
            Console.WriteLine(result.CommandText);
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