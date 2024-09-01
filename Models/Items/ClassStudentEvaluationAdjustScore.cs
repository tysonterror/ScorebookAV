using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorebookAV.Models.Items
{
    public class ClassStudentEvaluationAdjustScore
    {
        public ClassStudentEvaluation ClassStudentEvaluation { get; set; }
        public PEvaluationTypeParam NewScore { get; set; }

        public ClassStudentEvaluationAdjustScore()
        {

        }
    }
}
