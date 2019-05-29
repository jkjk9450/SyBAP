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
using SyBAP.Applications.Views;

namespace SyBAP.Presentation.Views
{
    /// <summary>
    /// PropertyView.xaml에 대한 상호 작용 논리
    /// </summary>
    [Export, Export(typeof(IPropertyView))]
    public partial class PropertyView : UserControl, IPropertyView
    {
        public PropertyView()
        {
            InitializeComponent();
        }
    }
}