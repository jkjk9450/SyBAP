﻿using System.ComponentModel.Composition;
using System.Waf.Applications;
using SyBAP.Applications.Views;

namespace SyBAP.Applications.ViewModels
{
    [Export]
    public class RibbonViewModel : ViewModel<IRibbonView>
    {
        private DelegateCommand _commandList;

        [ImportingConstructor]
        public RibbonViewModel(IRibbonView view) : base(view)
        {
        }

        public DelegateCommand CommandList
        {
            get => _commandList;
            set => SetProperty(ref _commandList, value);
        }

        private DelegateCommand _commandImport;

        public DelegateCommand CommandImport
        {
            get => _commandImport;
            set => SetProperty(ref _commandImport, value);
        }

        private DelegateCommand _commandExport;

        public DelegateCommand CommandExport
        {
            get => _commandExport;
            set => SetProperty(ref _commandExport, value);
        }
    }
}