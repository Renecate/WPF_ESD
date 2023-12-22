namespace Explorer.Shared.ViewModels
{
    public sealed class DirectoryViewMoodel : FileEntityViewModel
    {
        public DirectoryViewMoodel(string directoryName) : base(directoryName) 
        {
            FullName = directoryName;
        }

        public DirectoryViewMoodel(DirectoryInfo directoryName) : base(directoryName.Name)
        {
            FullName = directoryName.FullName;
        }
    }
}
