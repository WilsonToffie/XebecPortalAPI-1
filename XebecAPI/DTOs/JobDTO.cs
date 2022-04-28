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

        public string Company { get; set; }

        public string Location { get; set; }

        public string Policy { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDTO Department { get; set; }

        public string Status { get; set; }

        public int? AppUserId { get; set; }
        public AppUserDTO AppUser { get; set; }

        public DateTime DueDate { get; set; }
        public string JobType { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
