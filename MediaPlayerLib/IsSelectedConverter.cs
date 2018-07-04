//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System;
using System.Globalization;
using System.Windows.Data;

namespace MediaPlayerLib
{
    /// <summary>
    /// Returnerar true ifall ett värde är > -1, false annars.
    /// </summary>
    public class IsSelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int val = int.Parse(value.ToString());

            switch (val)
            {
                case -1:
                    return false;

                default:
                    return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
