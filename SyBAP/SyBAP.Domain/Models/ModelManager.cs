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
        private PostgreSQL _postgreSql;
        private Sqoop _sqoop;

        public void GetSqoop()
        {
            string host = "147.46.144.30";
            string username = "sydlab";
            string password = "123qwe!@#";
            string database = "digital_twin";

            string postusername = "dt_user";
            _hdfs = new HDFS(host, username, password);

            _postgreSql = new PostgreSQL(host, username, password, database);
            _sqoop = new Sqoop(_postgreSql, _hdfs);
            _sqoop.ListTable();
        }
    }
}