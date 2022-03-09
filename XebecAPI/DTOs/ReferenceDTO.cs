using System;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs
{
    public class ReferenceDTO
    {
        public int Id { get; set; }

        public string RefFirstName { get; set; }

        public string RefLastName { get; set; }

        public string RefPhone { get; set; }

        public string RefEmail { get; set; }

        public string Relationship { get; set; }

        //Foreign Key: AppUser
        public int AppUserId { get; set; }

        public AppUserDTO AppUser { get; set; }



    }
}
