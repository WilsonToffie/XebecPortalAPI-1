using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs
{
    public class CollaboratorQuestionDTO
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }

        public AppUserDTO AppUser { get; set; }

        public int QuestionnaireHrFormId { get; set; }

        public QuestionnaireHRFormDTO QuestionnaireHRForm { get; set; }
    }
}
