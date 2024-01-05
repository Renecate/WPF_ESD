using Explorer.Shared.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Explorer.WPF.UI
{
    public partial class MainWindow
    {
        private readonly MainViewModel _mainVm;

        public MainWindow()
        {
            InitializeComponent();

            _mainVm = new MainViewModel();

            DataContext = _mainVm;
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainVm.ApplicationClosing();

            Application.Current.Shutdown();
        }

        private void ExpandButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void HideButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}