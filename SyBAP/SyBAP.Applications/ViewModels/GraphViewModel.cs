using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using SyBAP.Applications.Views;

namespace SyBAP.Applications.ViewModels
{
    [Export]
    public class GraphViewModel : ViewModel<IGraphView>
    {
        [ImportingConstructor]
        public GraphViewModel(IGraphView view) : base(view)
        {
        }

        public void SelectedTreeNodeCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
        }
    }
}