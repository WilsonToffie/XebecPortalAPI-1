using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
    public class DeveloperAssigned
    {
        public int Id { get; set; }

        //foreign key:Job
        public int JobId { get; set; }
        public Job Job { get; set; }

        //foreign key:AppUser
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        //foreign key:AppPhase
        public int ApplicationPhaseId { get; set; }
        public ApplicationPhase ApplicationPhase { get; set; }
    }
}
