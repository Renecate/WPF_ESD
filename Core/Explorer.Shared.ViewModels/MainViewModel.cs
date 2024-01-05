using System.Collections.ObjectModel;
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


        #endregion

        #region Constructor

        public MainViewModel()
        {
            AddTabItemCommmand = new DelegateCommand(OnAddTabItem);

            AddTabItemViewModel();

            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }


        #endregion

        #region Commands Methods

        #endregion

        #region Private Methods

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();

            vm.Closed += Vm_Closed;

            DirectoryTabItems.Add(vm);
        }

        private void Vm_Closed(object? sender, EventArgs e)
        {
            if (sender is DirectoryTabItemViewModel directoryTabItemViewModel) 
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            directoryTabItemViewModel.Closed -= Vm_Closed;

            DirectoryTabItems.Remove(directoryTabItemViewModel);

            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
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
        #endregion
    }
}