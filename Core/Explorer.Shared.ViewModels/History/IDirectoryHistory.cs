using System;
using System.Data.SqlTypes;

namespace Explorer.Shared.ViewModels
{
    internal interface IDirectoryHistory : IEnumerable<DirectoryNode>
    {
        bool CanMoveBack { get; }

        bool CanMoveForward { get; }

        DirectoryNode Current {  get; }

        event EventHandler HistoryChanged;

        void Add(string filePath, string name);

        void MoveBack();

        void MoveForward();  
    }
    internal class DirectoryNode
    {
        public string DirectoryPath { get; set; }
        public string? DirectoryPathName { get; internal set; }
    }
}
