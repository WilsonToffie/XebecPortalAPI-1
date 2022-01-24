using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs
{
    public class AdditionalInformationDTO
    {
        public int Id { get; set; }

        public string Disability { get; set; }

        public string Gender { get; set; }

        public string Ethnicity { get; set; }


        //foreign key
        public int AppUserId { get; set; }

        public AppUserDTO AppUser { get; set; }


    }
}