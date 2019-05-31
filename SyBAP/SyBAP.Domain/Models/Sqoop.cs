using Npgsql;
using Renci.SshNet;
using System;
using System.Collections.Generic;

namespace SyBAP.Domain.Models
{
    public class Sqoop : Group
    {
        private PostgreSQL postgresql;
        private HDFS hdfs;

        public Sqoop(PostgreSQL postgresql, HDFS hdfs)
        {
            this.postgresql = postgresql;
            this.hdfs = hdfs;
        }

        public void ListTable()
        {
            hdfs.RunCommand(String.Format("sudo -S sqoop list-tables --connect jdbc:postgresql://{0}/{1}  --username {3} --password '{4}'", postgresql.host, postgresql.database, postgresql.username, postgresql.password));
            //hdfs.RunCommand("sudo -S sqoop list-tables --connect jdbc:postgresql://147.46.144.30/digital_twin --username dt_user --password '123qwe!@#';");
            hdfs.RunCommand(hdfs.password);
        }
    }

    public class PostgreSQL
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        public string host;
        public string username;
        public string password;
        public string database;

        public PostgreSQL(string host, string username, string password, string database)
        {
            this.host = host;
            this.username = username;
            this.password = password;
            this.database = database;
            try
            {
                conn = new NpgsqlConnection(String.Format("Host={0};Username={1};Password={2};Database={3}", host, username,
                    password, database));
                conn.Open();
                cmd = new NpgsqlCommand();
                cmd.Connection = conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<string> GetTableList(string schema)
        {
            List<string> TableList = new List<string>();
            cmd.CommandText = "select * from pg_tables where schemaname = '" + schema + "';";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string tablename = reader["tablename"].ToString();
                TableList.Add(tablename);
            }
            reader.Close();
            return TableList;
        }

        public void Command(string command)
        {
            try
            {
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Disconnect()
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public class HDFS
    {
        private SshClient client;
        public string password;

        public HDFS(string host, string username, string password)
        {
            client = new SshClient(host, username, password);
            this.password = password;
            client.Connect();
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