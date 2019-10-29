using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace FlashcardsPF.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool state = (bool)value;
            if (state)
                return Visibility.Visible;
            else if (!state)
                return Visibility.Hidden;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            if (visibility == Visibility.Visible)
                return true;
            else if (visibility == Visibility.Hidden)
                return false;
            return null;
        }
    }
}
