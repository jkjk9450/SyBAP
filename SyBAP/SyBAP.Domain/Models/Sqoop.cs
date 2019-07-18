using Npgsql;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace SyBAP.Domain.Models
{
    public class Sqoop : Group
    {
        private OracleDB postgresql;
        private HDFS hdfs;

        public Sqoop()
        {
            this.postgresql = new OracleDB(OracleHost, OracleUserName, OraclePassword, TableName);
            this.hdfs = new HDFS(HdfsHost, HdfsUsername, HdfsPassword);
        }

        public void ExecuteListTable()
        {
            hdfs.RunCommand(String.Format(
                "sudo -S sqoop list-tables --connect jdbc:postgresql://{0}/{1}  --username {2} --password '{3}'",
                postgresql.host, postgresql.database, postgresql.username, postgresql.password));
            //hdfs.RunCommand("sudo -S sqoop list-tables --connect jdbc:postgresql://147.46.144.30/digital_twin --username dt_user --password '123qwe!@#';");
            hdfs.RunCommand(hdfs.password);
        }

        public void ExecuteImportTable()
        {
        }

        public void ExecuteExportTable()
        {
        }

        private string _hdfsHost = "10.4.99.47";

        [Category("HDFS")]
        [DisplayName("HDFSHost")]
        public string HdfsHost
        {
            get => _hdfsHost;
            set => SetProperty(ref _hdfsHost, value);
        }

        private string _hdfsUsername = "root";

        [DisplayName("UserName")]
        public string HdfsUsername
        {
            get => _hdfsUsername;
            set => SetProperty(ref _hdfsUsername, value);
        }

        private string _hdfsPassword = "hhiplm2018";

        [DisplayName("Password")]
        public string HdfsPassword
        {
            get => _hdfsPassword;
            set => SetProperty(ref _hdfsPassword, value);
        }

        private string _oracleHost = "10.100.32.67";

        [Category("OracleDB")]
        [DisplayName("Host")]
        public string OracleHost
        {
            get => _oracleHost;
            set => SetProperty(ref _oracleHost, value);
        }

        private string _oracleUserName = "sys as sysdba";

        [DisplayName("UserName")]
        public string OracleUserName
        {
            get => _oracleUserName;
            set => SetProperty(ref _oracleUserName, value);
        }

        private string _oraclePassword = "system";

        [DisplayName("Password")]
        public string OraclePassword
        {
            get => _oraclePassword;
            set => SetProperty(ref _oraclePassword, value);
        }

        private string _oracleSID = "orcl";

        [DisplayName("SID")]
        public string OracleSID
        {
            get => _oracleSID;
            set => SetProperty(ref _oracleSID, value);
        }

        private string _oraclePort = "1521";

        [DisplayName("Port")]
        public string OraclePort
        {
            get => _oraclePort;
            set => SetProperty(ref _oraclePort, value);
        }

        private string _tableName;

        [DisplayName("TargetTable")]
        public string TableName
        {
            get => _tableName;
            set => SetProperty(ref _tableName, value);
        }

        private string _importDirectory;

        public string ImportDirectory
        {
            get => _importDirectory;
            set => SetProperty(ref _importDirectory, value);
        }

        private string _exportDirectory;

        public string ExportDirectory
        {
            get => _exportDirectory;
            set => SetProperty(ref _exportDirectory, value);
        }
    }
}