using System;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
    public class Education
    {
        public int Id { get; set; }

        public string Insitution { get; set; }

        public string Qualification { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //Foreign Key: AppUser
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }


        
    }
}
