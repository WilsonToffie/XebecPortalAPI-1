using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.DTOs;

namespace XebecAPI.DTOs
{
    public class QuestionnaireHRFormDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int JobId { get; set; }
        public JobDTO Job { get; set; }
    }
}
