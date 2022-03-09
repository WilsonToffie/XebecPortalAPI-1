using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.DTOs
{
    public class CandidateRecommenderDTO
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUserDTO AppUser { get; set; }

        public int JobId { get; set; }
        public JobDTO Job { get; set; }

        public double TotalMatch { get; set; }
    }
}
