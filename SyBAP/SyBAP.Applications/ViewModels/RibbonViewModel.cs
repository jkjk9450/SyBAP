using System.ComponentModel.Composition;
using System.Waf.Applications;
using SyBAP.Applications.Views;

namespace SyBAP.Applications.ViewModels
{
    [Export]
    public class RibbonViewModel : ViewModel<IRibbonView>
    {
        private DelegateCommand _commandCompute;

        [ImportingConstructor]
        public RibbonViewModel(IRibbonView view) : base(view)
        {
        }

        public DelegateCommand CommandCompute
        {
            get => _commandCompute;
            set => SetProperty(ref _commandCompute, value);
        }
    }
}