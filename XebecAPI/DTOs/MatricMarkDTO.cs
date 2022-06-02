using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.DTOs
{
    public class MatricMarkDTO
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int SubjectMark { get; set; }
        public int AppUserId { get; set; }
        public AppUserDTO AppUser { get; set; }
    }
}
