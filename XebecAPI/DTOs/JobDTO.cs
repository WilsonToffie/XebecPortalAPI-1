using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public int? CompanyId { get; set; }

        public CompanyDTO Company { get; set; }

        public decimal? Compensation { get; set; }

        public int? MinimumExperience { get; set; }
        public int? LocationId { get; set; }

        public LocationDTO Location { get; set; }
        public int? PolicyID { get; set; }

        public PolicyDTO Policy { get; set; }

        public int? DepartmentId { get; set; }

        public DepartmentDTO Department { get; set; }

        public string? Status { get; set; }

        public int? AppUserId { get; set; }
        public AppUserDTO AppUser { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreationDate { get; set; }       
    }
}
