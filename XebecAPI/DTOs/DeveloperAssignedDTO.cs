using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.DTOs
{
    public class DeveloperAssignedDTO
    {
       public int Id { get; set; }
        //foreign keys
        public int JobId { get; set; }
        public JobDTO Job { get; set; }
     
        public int AppUserId { get; set; }
        public AppUserDTO AppUser { get; set; }

        public int ApplicationPhaseId { get; set; }
        public ApplicationPhaseDTO ApplicationPhase { get; set; }
    }
}
