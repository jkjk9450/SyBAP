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
                        SelectedObject = item as Sqoop;
                    }
                    break;
            }
        }

        private Sqoop _selectedObject;

        public Sqoop SelectedObject
        {
            get => _selectedObject;
            set => SetProperty(ref _selectedObject, value);
        }
    }
}