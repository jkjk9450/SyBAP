using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using SyBAP.Applications.Views;
using SyBAP.Domain.Models;

namespace SyBAP.Applications.ViewModels
{
    [Export]
    public class PropertyViewModel : ViewModel<IPropertyView>
    {
        [ImportingConstructor]
        public PropertyViewModel(IPropertyView view) : base(view)
        {
        }

        public void SelectedTreeNodeCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        _selectedObject = item as ModelBase;
                    }
                    break;
            }
        }

        private ModelBase _selectedObject;

        public ModelBase SelectedObject
        {
            get => _selectedObject;
            set => SetProperty(ref _selectedObject, value);
        }
    }
}