namespace SyBAP.Domain.Models
{
    public class Project : Group
    {
        public Project()
        {
            Name = "Project";
            Children.Add(DataModels);
        }

        private Group _dataModels = new Group() { Name = "DataModels" };

        public Group DataModels
        {
            get => _dataModels;
            set => SetProperty(ref _dataModels, value);
        }
    }
}