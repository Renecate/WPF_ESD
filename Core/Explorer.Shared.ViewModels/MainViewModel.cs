using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        public string FilePath { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new ObservableCollection<FileEntityViewModel>();

        #endregion

        #region Constructor

        public MainViewModel()
        {
            foreach (var logicalDrive in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewMoodel(logicalDrive));
            }
        }
        #endregion
    }
}
