﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs
{
   public class DocumentsDTO
    {
        public int Id { get; set; }

        public string DocumentName { get; set; }

        public string DocumentUrl { get; set; }

        public int AppUserId { get; set; }

        public AppUserDTO AppUser { get; set; }
    }
}
