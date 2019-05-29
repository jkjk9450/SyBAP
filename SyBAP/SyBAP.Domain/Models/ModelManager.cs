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
    }
}