using System.Waf.Foundation;

namespace SyBAP.Domain.Models
{
    public class ModelManager : Model
    {
        private ModelManager()
        {
        }

        private static ModelManager _uniqueInstance;

        public static ModelManager GetInstance()
        {
            if (_uniqueInstance == null)
            {
                _uniqueInstance = new ModelManager();
            }

            return _uniqueInstance;
        }

        private Project _project = new Project();

        public Project Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        public void CreateProject()
        {
            Project = new Project();
        }

        private HDFS _hdfs;
        private OracleDB _postgreSql;
        private Sqoop _sqoop;

        public void CreateModel()
        {
            //string sqlhost = "";
            //string sqlname = "";
            //string sqlpsw = "";
            //string sqldatabase = "";
            //string hdfshost = "147.46.144.30";
            //string hdfsname = "root";
            //string hdfspsw = "!34ehd312gh@";

            //PostgreSQL postgreSql = new PostgreSQL(sqlhost, sqlname, sqlpsw, sqldatabase);
            //HDFS hdfs = new HDFS(hdfshost, hdfsname, hdfspsw);
            //Sqoop sqoop = new Sqoop(postgreSql, hdfs);
            Sqoop sqoop = new Sqoop();
            SqoopExample = sqoop;
            SqoopExample.Name = "Example1";
            Project.DataModels.Children.Add(SqoopExample);
        }

        public Sqoop SqoopExample;
    }
}