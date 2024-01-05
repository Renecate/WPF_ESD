
using System.Collections;

namespace Explorer.Shared.ViewModels
{
    internal class DirectoryHistory : IDirectoryHistory
    {
        public DirectoryHistory(string directoryPath, string directoryPathName)
        {

        }

        public bool CanMoveBack => throw new NotImplementedException();

        public bool CanMoveForward => throw new NotImplementedException();

        public DirectoryNode Current => throw new NotImplementedException();

        public event EventHandler HistoryChanged;

        public void Add(string filePath, string name)
        {
            throw new NotImplementedException();
        }



        public void MoveBack()
        {
            throw new NotImplementedException();
        }

        public void MoveForward()
        {
            throw new NotImplementedException();
        }

        #region Enumerator

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<DirectoryNode> GetEnumerator()
        {

        }

        #endregion
    }
}
