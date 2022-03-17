using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs.ViewModels
{
    public class ApplicantPortalView
    {
        public  CandidateRecommender User { get; set; }
        public ApplicationPhaseHelper PhaseHelper { get; set; }
    }
}
