using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;

namespace XebecAPI.DTOs.ViewModels
{
    public class UserViewModel
    {
        public string Role { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
    }
}
