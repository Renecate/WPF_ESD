using Explorer.Shared.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Explorer.WPF.UI
{
    internal class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var drawingImage = new DrawingImage();

            if (value is DirectoryViewModel directoryVm)
            {
                var resource = Application.Current.TryFindResource("FolderIconImage");

                if (resource is ImageSource directoryImageSource)
                    return directoryImageSource;
            }

            else if (value is FileViewModel fileVm)
            {
                var resource = Application.Current.TryFindResource("FileIconImage");

                if (resource is ImageSource directoryImageSource)
                    return directoryImageSource;
            }

                return drawingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
