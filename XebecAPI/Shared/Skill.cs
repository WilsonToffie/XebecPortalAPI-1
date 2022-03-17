using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
    public class Skill
    {
        public int Id { get; set; }

        public string Description { get; set; }

        //Foreign Key: AppUser
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
