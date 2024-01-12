using System.Collections.ObjectModel;

namespace Explorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Private Fields

        private IDirectoryHistory _history; 

        #endregion

        #region Public Properties

        public string FilePath { get; set; }

        public string Name { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = [];

        public FileEntityViewModel SelectedFileEntity { get; set; }

        #endregion

        #region Commands
        public DelegateCommand OpenCommand { get; }

        public DelegateCommand MoveBackCommand { get; }

        public DelegateCommand MoveForwardCommand { get; }

        #endregion

        #region Events

        public event EventHandler Closed;

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {
            _history = new DirectoryHistory("My PC", "My PC");

            OpenCommand = new DelegateCommand(Open);
            MoveBackCommand = new DelegateCommand(OnMoveBack, OnCanMoveBack);
            MoveForwardCommand = new DelegateCommand(OnMoveForward, OnCanMoveForvard);

            Name = _history.Current.DirectoryPathName;
            FilePath = _history.Current.DirectoryPath;

            OpenDirectory();

            _history.HistoryChanged += History_HistoryChanged;
        }



        #endregion

        #region Commands Methods

        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewMoodel)
            {
                FilePath = directoryViewMoodel.FullName;
                Name = directoryViewMoodel.Name;

                _history.Add(FilePath, Name); 

                OpenDirectory();
            }
        }

        private bool OnCanMoveForvard(object obj) => _history.CanMoveForward;

        private void OnMoveForward(object obj)
        {
            _history.MoveForward();

            var current = _history.Current;

            FilePath = current.DirectoryPath;
            Name = current.DirectoryPathName;

            OpenDirectory();
        }

        private bool OnCanMoveBack(object obj) => _history.CanMoveBack;

        private void OnMoveBack(object obj)
        {
            _history.MoveBack();

            var current = _history.Current;

            FilePath = current.DirectoryPath;
            Name = current.DirectoryPathName;

            OpenDirectory();
        }
        #endregion

        #region Private Methods
        private void OpenDirectory()
        {
            DirectoriesAndFiles.Clear();

            if (Name == "My PC")
            {
                foreach (var logicalDrive in Directory.GetLogicalDrives())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
                }
                return;
            }

            var directoryInfo = new DirectoryInfo(FilePath);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
            }

            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                DirectoriesAndFiles.Add(new FileViewModel(fileInfo));
            }
        }

        private void History_HistoryChanged(object? sender, EventArgs e)
        {
            MoveBackCommand?.RaiseCanExecuteChanged();
            MoveForwardCommand?.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
