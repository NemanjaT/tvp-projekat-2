using System;
using Windows.UI.Xaml.Data;

namespace ProjekatTVP2.ViewModels.Converters
{
    class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool val = (bool)value;
            if (parameter != null)
                val = !val;
            return (bool)val ? "Visible" : "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (string)value == "Visible";
        }
    }
}
