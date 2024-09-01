using Avalonia.Data.Converters;
using ScorebookAV.Models;
using ScorebookAV.Models.Items;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorebookAV.Converters
{
    public class StudentEvaluationAdjustScoreConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count != 2)
                return Avalonia.AvaloniaProperty.UnsetValue;

            if (values[0] is not ClassStudentEvaluation || values[1] is not PEvaluationTypeParam)
                return null;

            return new ClassStudentEvaluationAdjustScore() { ClassStudentEvaluation = (ClassStudentEvaluation)values[0], NewScore = (PEvaluationTypeParam)values[1] };

        }
    }
}
