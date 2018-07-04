//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace MediaPlayerLib
{
    /// <summary>
    /// Returnerar DependencyProperty.UnsetValue ifall den string som är bunden till en Image.source är null.
    /// </summary>
    public class NullImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
