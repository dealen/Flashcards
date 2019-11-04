using Flashcards.Lib.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace FlashcardsPF.Converters
{
    public class MultiParameterToSingleObjectConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null)
            {
                var list = values[0] as List<Word>;
                var flag = (bool)values[1];
                var model = new WindowParameter(list, flag);
                return model;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var model = value as WindowParameter;
                var obj = new object[] { model.Words, model.IsTranslated };
                return obj;
            }
            return null;
        }
    }
}
