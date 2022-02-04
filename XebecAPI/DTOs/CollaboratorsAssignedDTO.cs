using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.DTOs
{
    public class CollaboratorsAssignedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AppUserId { get; set; }
        public AppUserDTO AppUser { get; set; }

        public int JobId { get; set; }
        public JobDTO Job { get; set; }
    }
}
