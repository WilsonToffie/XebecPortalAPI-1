using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
    public class AdditionalInformation
    {
        public int Id { get; set; }

        public string Disability { get; set; }

        public string Gender { get; set; }

        public string Ethnicity { get; set; }


        //foreign key: AppUser
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }


    }
}