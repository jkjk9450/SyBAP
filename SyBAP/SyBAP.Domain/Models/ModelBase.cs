using System.Waf.Foundation;

namespace SyBAP.Domain.Models
{
    public class ModelBase : Model
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}