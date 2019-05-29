using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SyBAP.Domain.Models
{
    public class Group : ModelBase
    {
        private ObservableCollection<ModelBase> _childrenGroups = new ObservableCollection<ModelBase>();

        [Browsable(false)]
        public ObservableCollection<ModelBase> Children
        {
            get => _childrenGroups;
            set => SetProperty(ref _childrenGroups, value);
        }
    }
}