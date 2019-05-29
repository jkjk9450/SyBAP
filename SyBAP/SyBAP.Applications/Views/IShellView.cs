using System.Waf.Applications;

namespace SyBAP.Applications.Views
{
    public interface IShellView : IView
    {
        void Show();

        void Close();
    }
}