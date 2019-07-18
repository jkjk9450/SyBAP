using System;
using System.Collections.Generic;
using Npgsql;

namespace SyBAP.Domain.Models
{
    public class OracleDB : Group
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        public string host;
        public string username;
        public string password;
        public string database;

        public OracleDB(string host, string username, string password, string database)
        {
            this.host = host;
            this.username = username;
            this.password = password;
            this.database = database;
            //try
            //{
            //    conn = new NpgsqlConnection(String.Format("Host={0};Username={1};Password={2};Database={3}", host, username,
            //        password, database));
            //    conn.Open();
            //    cmd = new NpgsqlCommand();
            //    cmd.Connection = conn;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    //throw;
            //}
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
}