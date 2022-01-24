using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.DTOs.ViewModels
{
    public class ApplicantViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CstMark { get; set; }
        public string CstComment { get; set; }
        public int InterviewRating { get; set; }
        public string InterviewComment { get; set; }
        public string Phase { get; set; }
    }
}
