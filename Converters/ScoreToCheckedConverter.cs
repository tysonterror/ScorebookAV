using Avalonia.Data.Converters;
using Avalonia.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorebookAV.Models;

namespace ScorebookAV.Converters
{

    public class ScoreToCheckedConverter : IMultiValueConverter
    {

        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count != 2)
                return Avalonia.AvaloniaProperty.UnsetValue;

            if (values[0] is double? && values[1] is double?)
            {
                if ((double?)values[0] == (double?)values[1])
                    return true;
            }
            // converter used for the wrong type
            return new BindingNotification(new InvalidCastException(),
                                                    BindingErrorType.Error);
        }

        public object ConvertBack(object? value, Type targetType,
                                    object? parameter, CultureInfo culture)
        {
            return false;
            //throw new NotSupportedException();
        }
    }
}
