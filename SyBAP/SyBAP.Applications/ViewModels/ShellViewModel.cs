using System.ComponentModel.Composition;
using System.Waf.Applications;
using SyBAP.Applications.Views;

namespace SyBAP.Applications.ViewModels
{
    [Export]
    public class ShellViewModel : ViewModel<IShellView>
    {
        [ImportingConstructor]
        public ShellViewModel(IShellView view) : base(view)
        {
        }

        public void Show()
        {
            ViewCore.Show();
        }

        public void Close()
        {
            ViewCore.Close();
        }

        private object _contentRibbonView;

        public object ContentRibbonView
        {
            get => _contentRibbonView;
            set => SetProperty(ref _contentRibbonView, value);
        }

        private object _contentPropertyView;

        public object ContentPropertyView
        {
            get => _contentPropertyView;
            set => SetProperty(ref _contentPropertyView, value);
        }

        private object _contentTreeView;

        public object ContentTreeView
        {
            get => _contentTreeView;
            set => SetProperty(ref _contentTreeView, value);
        }

        private object _contentgraphView;

        public object ContentGraphView
        {
            get => _contentgraphView;
            set => SetProperty(ref _contentgraphView, value);
        }
    }
}