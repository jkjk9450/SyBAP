using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using SyBAP.Applications.Views;
using SyBAP.Domain.Models;

namespace SyBAP.Applications.ViewModels
{
    [Export]
    public class TreeViewModel : ViewModel<ITreeView>
    {
        public Group TreeNodeRoot { get; set; } = new Group();
        public ObservableCollection<object> SelectedTreeNodes { get; set; } = new ObservableCollection<object>();

        [ImportingConstructor]
        public TreeViewModel(ITreeView view) : base(view)
        {
        }

        public void ModelManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Project":
                    TreeNodeRoot.Children.Clear();
                    TreeNodeRoot.Children.Add(ModelManager.GetInstance().Project);
                    break;
            }
        }
    }
}