using System.ComponentModel.Composition;
using Fluent;
using SyBAP.Applications.Views;

namespace SyBAP.Presentation
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export, Export(typeof(IShellView))]
    public partial class ShellWindow : RibbonWindow, IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }
    }
}