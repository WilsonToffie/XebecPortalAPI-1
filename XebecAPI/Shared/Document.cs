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

        public string CV { get; set; }

        public string MatricCertificate { get; set; }

        public string UniversityTranscript { get; set; }

        public string AdditionalCert1 { get; set; }

        public string AdditionalCert2 { get; set; }

        public string AdditionalCert3 { get; set; }


        //Foreign Key: AppUser
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
