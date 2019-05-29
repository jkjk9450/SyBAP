using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Xml.Serialization;
using SyBAP.Applications.ViewModels;
using SyBAP.Domain.Models;

namespace SyBAP.Applications.Controller
{
    [Export(typeof(IModuleController)), Export]
    public class ModuleController : IModuleController
    {
        private ShellViewModel _shellViewModel;
        private RibbonViewModel _ribbonViewModel;
        private GraphViewModel _graphViewModel;
        private TreeViewModel _treeViewModel;
        private PropertyViewModel _propertyViewModel;

        private DelegateCommand _commandCompute;

        [ImportingConstructor]
        public ModuleController(ShellViewModel shellViewModel, RibbonViewModel ribbonViewModel, TreeViewModel treeViewModel, PropertyViewModel propertyViewModel, GraphViewModel graphViewModel)
        {
            _shellViewModel = shellViewModel;
            _ribbonViewModel = ribbonViewModel;
            _treeViewModel = treeViewModel;
            _propertyViewModel = propertyViewModel;
            _graphViewModel = graphViewModel;

            _commandCompute = new DelegateCommand(ExecuteCompute);
        }

        private void ExecuteCompute()
        {
        }

        public void Initialize()
        {
            _shellViewModel.ContentRibbonView = _ribbonViewModel.View;
            _shellViewModel.ContentTreeView = _treeViewModel.View;
            _shellViewModel.ContentPropertyView = _propertyViewModel.View;
            _shellViewModel.ContentGraphView = _graphViewModel.View;

            _ribbonViewModel.CommandCompute = _commandCompute;

            ModelManager.GetInstance().PropertyChanged += _treeViewModel.ModelManagerPropertyChanged;
            ModelManager.GetInstance().CreateProject();

            _treeViewModel.SelectedTreeNodes.CollectionChanged += _propertyViewModel.SelectedTreeNodeCollectionChange;
            _treeViewModel.SelectedTreeNodes.CollectionChanged += _graphViewModel.SelectedTreeNodeCollectionChange;
        }

        public void Run()
        {
            _shellViewModel.Show();
        }

        public void Shutdown()
        {
            _shellViewModel.Close();
        }
    }
}