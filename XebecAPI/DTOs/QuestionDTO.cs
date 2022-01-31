using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;

namespace XebecAPI.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string QuestionDescription { get; set; }

        //Foreign Key: AnswerType 

        public int AnswerTypeId { get; set; }

        public AnswerType AnswerType { get; set; }

    }
}
