using System;
using System.ComponentModel;

namespace SyBAP.Domain.Models
{
    public class Sqoop : Group
    {
        private OracleDB postgresql;
        private HDFS hdfs;

        public Sqoop()
        {
            this.postgresql = new OracleDB(OracleHost, OracleUserName, OraclePassword, OracleSID);
            this.hdfs = new HDFS(HdfsHost, HdfsUsername, HdfsPassword);
        }

        public void ExecuteListTable()
        {
            hdfs.RunSudoCommand(String.Format(
                "sqoop list-tables --connect jdbc:postgresql://{0}/{1}  --username {2} --password '{3}'",
                postgresql.host, postgresql.database, postgresql.username, postgresql.password));

            //postgresql.GetTableList("kr");
        }

        public void ExecuteImportTable()
        {
            hdfs.RunSudoCommand(String.Format(
                "sqoop import --connect jdbc:postgresql://{0}/{1} --username {2} --password '{3}' --table {4} --target-dir /user/{5}",
                postgresql.host, postgresql.database, postgresql.username, postgresql.password, TableName, ImportDirectory
                ));
        }

        public void ExecuteExportTable()
        {
            string tableName = "sample_test";
            hdfs.RunSudoCommand(String.Format("-u hdfs sqoop export --connect jdbc:postgresql://{0}/{1} --username {2} --password '{3}' --table {4} --export-dir hdfs://{0}/user/{5}"
            , postgresql.host, postgresql.database, postgresql.username, postgresql.password, tableName, ExportDirectory)
            );
        }

        private string _hdfsHost = "147.46.144.30";

        [Category("HDFS")]
        [DisplayName("HDFSHost")]
        public string HdfsHost
        {
            get => _hdfsHost;
            set => SetProperty(ref _hdfsHost, value);
        }

        private string _hdfsUsername = "sydlab";

        [DisplayName("UserName")]
        public string HdfsUsername
        {
            get => _hdfsUsername;
            set => SetProperty(ref _hdfsUsername, value);
        }

        private string _hdfsPassword = "123qwe!@#";

        [DisplayName("Password")]
        public string HdfsPassword
        {
            get => _hdfsPassword;
            set => SetProperty(ref _hdfsPassword, value);
        }

        private string _oracleHost = "147.46.144.30";

        [Category("OracleDB")]
        [DisplayName("Host")]
        public string OracleHost
        {
            get => _oracleHost;
            set => SetProperty(ref _oracleHost, value);
        }

        private string _oracleUserName = "dt_user";

        [DisplayName("UserName")]
        public string OracleUserName
        {
            get => _oracleUserName;
            set => SetProperty(ref _oracleUserName, value);
        }

        private string _oraclePassword = "123qwe!@#";

        [DisplayName("Password")]
        public string OraclePassword
        {
            get => _oraclePassword;
            set => SetProperty(ref _oraclePassword, value);
        }

        private string _oracleSID = "digital_twin";

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

        private string _tableName = "M211549000";

        [DisplayName("TargetTable")]
        public string TableName
        {
            get => _tableName;
            set => SetProperty(ref _tableName, value);
        }

        private string _importDirectory = "test_1";

        public string ImportDirectory
        {
            get => _importDirectory;
            set => SetProperty(ref _importDirectory, value);
        }

        private string _exportDirectory = "digital_twin_test";

        public string ExportDirectory
        {
            get => _exportDirectory;
            set => SetProperty(ref _exportDirectory, value);
        }
    }
}