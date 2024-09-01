using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;
using ScorebookAV.Models;
using ScorebookAV.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScorebookAV.TemplateSelectors
{
    public class EvaluationTypeTemplateSelector : IDataTemplate
    {
        [Content]
        public Dictionary<int, IDataTemplate> AvailableTemplates { get; } = new Dictionary<int, IDataTemplate>();

        public Control? Build(object? param)
        {
            int key;
            if (param is ClassStudentEvaluation == false)
                throw new ArgumentNullException(nameof(param));

            key = ((ClassStudentEvaluation)param).ClassEvaluation.EvaluationTypeId;

            return AvailableTemplates[key].Build(param); // finally we look up the provided key and let the System build the DataTemplate for us
        }

        public bool Match(object? data)
        {
            try
            {
                int key;
                if (data is ClassStudentEvaluation == false)
                    return false;

                key = ((ClassStudentEvaluation)data).ClassEvaluation.EvaluationTypeId;

                return data is ClassStudentEvaluation && key != 0 && AvailableTemplates.ContainsKey(key);

            }
            catch(Exception ex)
            {
                //ToDo:add loggin
            }
            return false;
        }
    }
}
