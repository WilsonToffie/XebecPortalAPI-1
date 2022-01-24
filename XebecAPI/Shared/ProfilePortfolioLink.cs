using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
   public class ProfilePortfolioLink
    {
        public int Id  { get; set; }

        public string GitHubLink { get; set; }

        public string LinkedInLink{ get; set; }

        public string TwitterLink { get; set; }

        public string PersonalWebsiteUrl { get; set; }

        //foreign key: AppUser
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }


    }
}
