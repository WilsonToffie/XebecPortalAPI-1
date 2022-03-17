using System;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs
{
    public class SkillDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int AppUserId { get; set; }

        public AppUserDTO AppUser { get; set; }


        
    }
}
