using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class QuestionnaireHRForm
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        //Foreign Key: Job
        public int JobId { get; set; }
        public Job Job { get; set; }

        //Foreign Key: AnswerType 

        public int AnswerTypeId { get; set; }

        public AnswerType AnswerType { get; set; }
    }
}
