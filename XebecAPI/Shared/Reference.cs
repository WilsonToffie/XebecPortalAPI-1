using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
    public class Reference
    {
        public int Id { get; set; }

        public string RefFirstName { get; set; }

        public string RefLastName { get; set; }

        public string? RefPhone { get; set; }

        public string? RefEmail { get; set; }

        public string Relationship { get; set; }

        //Foreign Key: AppUser
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

    }
}
