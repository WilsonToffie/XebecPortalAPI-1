using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class Question
    {

        public int Id { get; set; }

        public string QuestionDescription { get; set; }

        //Foreign Key: AnswerType 

        public int AnswerTypeId { get; set; }

        public AnswerType AnswerType { get; set; }
    }
}
