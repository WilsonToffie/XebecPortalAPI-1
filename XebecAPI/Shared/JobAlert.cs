using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
    public class JobAlert
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
