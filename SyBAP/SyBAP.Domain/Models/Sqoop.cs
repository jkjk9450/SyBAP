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
            hdfs.RunCommand(String.Format(
                "sudo -S sqoop list-tables --connect jdbc:postgresql://{0}/{1}  --username {2} --password '{3}'",
                postgresql.host, postgresql.database, postgresql.username, postgresql.password));
            //hdfs.RunCommand("sudo -S sqoop list-tables --connect jdbc:postgresql://147.46.144.30/digital_twin --username dt_user --password '123qwe!@#';");
            hdfs.RunCommand(hdfs.password);
        }
    }
}