using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } =
            [];

        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        #endregion

        #region Commands

        public DelegateCommand AddTabItemCommmand { get; }

        public DelegateCommand CloseCommand { get; }
        #endregion

        #region Constructor

        public MainViewModel()
        {
            AddTabItemCommmand = new DelegateCommand(OnAddTabItem);

            AddTabItemViewModel();

            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();

            CloseCommand = new DelegateCommand(OnClose);
        }


        #endregion

        #region Commands Methods

        #endregion

        #region Private Methods

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();

            DirectoryTabItems.Add(vm);
        }


        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {

            DirectoryTabItems.Remove(directoryTabItemViewModel);
        }
        private void OnAddTabItem(object obj)
        {
            AddTabItemViewModel();

            CurrentDirectoryTabItem = DirectoryTabItems.Last();
        }

        #endregion


        #region Public Methods
        public void ApplicationClosing()
        {
            
        }
        private void OnClose(object obj)
        {
            if (obj is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }
        #endregion
    }
}