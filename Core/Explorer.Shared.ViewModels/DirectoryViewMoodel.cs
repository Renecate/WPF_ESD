namespace Explorer.Shared.ViewModels
{
    public class DirectoryViewMoodel : FileEntityViewModel
    {
        public string DirectoryName { get; }

        public DirectoryViewMoodel(string directoryName)
        {
            DirectoryName = directoryName;
        }
    }
}
