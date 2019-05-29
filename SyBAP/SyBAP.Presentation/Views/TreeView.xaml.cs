using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SyBAP.Applications.ViewModels;
using SyBAP.Applications.Views;

namespace SyBAP.Presentation.Views
{
    /// <summary>
    /// TreeView.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export, Export(typeof(ITreeView))]
    public partial class TreeView : UserControl, ITreeView
    {
        public TreeView()
        {
            InitializeComponent();
        }

        private void treeView_SelectionChanged(object sender, EventArgs e)
        {
            TreeViewModel viewModel = DataContext as TreeViewModel;
            viewModel.SelectedTreeNodes.Clear();
            foreach (var selectedItem in treeView.SelectedItems)
            {
                viewModel.SelectedTreeNodes.Add(selectedItem);
            }
        }
    }
}