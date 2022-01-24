using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs
{
    public class QuestionnaireApplicantFormDTO
    {

        public int Id { get; set; }
        public int QuestionnaireHRFormId { get; set; }

        public string ApplicantAnswer { get; set; }
        public int AppUserId { get; set; }

        public QuestionnaireHRFormDTO QuestionnaireHRForm { get; set; }
        public AppUserDTO User { get; set; }
    }
}
