using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.DTOs
{
    public class JobArletsDTO
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public int AppUserId { get; set; }
        public AppUserDTO AppUser { get; set; }
    }
}
