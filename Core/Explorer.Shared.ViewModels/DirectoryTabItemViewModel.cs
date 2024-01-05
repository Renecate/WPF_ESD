using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Public Properties

        public string FilePath { get; set; }

        public string Name { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new ObservableCollection<FileEntityViewModel>();

        public FileEntityViewModel SelectedFileEntity { get; set; }

        #endregion

        #region Commands
        public ICommand OpenCommand { get; }

        public ICommand CloseCommand { get; }

        #endregion

        #region Events

        public event EventHandler Closed;

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {
            Name = "My PC";

            OpenCommand = new DelegateCommand(Open);
            CloseCommand = new DelegateCommand(OnClose);

            foreach (var logicalDrive in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewMoodel(logicalDrive));
            }
        }
        #endregion

        #region Commands Methods

        private void Open(object parameter)
        {
            if (parameter is DirectoryViewMoodel directoryViewMoodel)
            {
                FilePath = directoryViewMoodel.FullName;

                Name = directoryViewMoodel.Name;

                DirectoriesAndFiles.Clear();

                var directoryInfo = new DirectoryInfo(FilePath);

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewMoodel(directory));
                }

                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    DirectoriesAndFiles.Add(new FileViewModel(fileInfo));
                }
            }
        }

        private void OnClose(object obj)
        {
            Closed?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}