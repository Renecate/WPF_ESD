using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = new ObservableCollection<DirectoryTabItemViewModel>();

        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public MainViewModel()
        {
            DirectoryTabItems.Add(new DirectoryTabItemViewModel());
        }
        #endregion

        #region Commands Methods

        #endregion
    }
}