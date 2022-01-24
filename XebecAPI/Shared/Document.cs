using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.Shared
{
   public class Document
    {
        public int Id { get; set; }

        public string DocumentName { get; set; }

        [Required]
        public string DocumentUrl { get; set; }

        //Foreign Key: AppUser
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
