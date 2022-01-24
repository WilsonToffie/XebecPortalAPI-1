using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
    public class QuestionnaireApplicantForm
    {
        public int Id { get; set; }

        public string ApplicantAnswer { get; set; }

        //Foreign Key: Questionnaire HRForm
        public int QuestionnaireHRFormId { get; set; }
        public QuestionnaireHRForm QuestionnaireHRForm { get; set; }

        //Foreign Key: AppUser
        public int AppUserId { get; set; }
        public AppUser User { get; set; }

    }
}
