using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
    public class Job
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public int? CompanyId { get; set; }

        public Company Company { get; set; }

        public decimal? Compensation { get; set; }

        public int? MinimumExperience { get; set; }
        public int? LocationId { get; set; }

        public Location Location { get; set; }
        public int? PolicyID { get; set; }

        public Policy Policy { get; set; }

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        public string? Status { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreationDate { get; set; }

        public List<JobTypeHelper> JobTypes { get; set; }
        public List<JobPlatformHelper> JobPlatforms  { get; set; }

        public List<JobApplicationPhase> JobPhases { get; set; }

        public List<Application> Applications { get; set; }

    }
}
