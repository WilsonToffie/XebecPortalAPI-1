using System;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs
{
    public class EducationDTO
    {
        public int Id { get; set; }

        public string Insitution { get; set; }

        public string Qualification { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

         public int AppUserId { get; set; }

        public AppUserDTO AppUser { get; set; }


        
    }
}
