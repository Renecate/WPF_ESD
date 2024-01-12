
using System.Collections;

namespace Explorer.Shared.ViewModels
{
    internal class DirectoryHistory : IDirectoryHistory
    {
        #region Private fields
        private DirectoryNode _head; 
        #endregion

        #region Properties
        public bool CanMoveBack => Current.PreviousNode != null;
        public bool CanMoveForward => Current.NextNode != null;

        public DirectoryNode Current { get; private set; } 
        #endregion

        #region Events
        public event EventHandler HistoryChanged;
        #endregion

        #region Constructor
        public DirectoryHistory(string directoryPath, string directoryPathName)
        {
            _head = new DirectoryNode(directoryPath, directoryPathName);
            Current = _head;
        }
        #endregion

        #region Public methods
        public void MoveBack()
        {
            var prev = Current.PreviousNode;

            Current = prev;

            RaiseHistoryChanged();
        }

        public void MoveForward()
        {
            var next = Current.NextNode;

            Current = next;

            RaiseHistoryChanged();
        }

        public void Add(string filePath, string name)
        {
            var node = new DirectoryNode(filePath, name);

            Current.NextNode = node;
            node.PreviousNode = Current;

            Current = node;

            RaiseHistoryChanged();
        } 
        #endregion

        #region Private methods
        private void RaiseHistoryChanged() => HistoryChanged?.Invoke(this, EventArgs.Empty); 
        #endregion

        #region Enumerator

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<DirectoryNode> GetEnumerator()
        {
            yield return Current;

        }

        #endregion
    }
}
