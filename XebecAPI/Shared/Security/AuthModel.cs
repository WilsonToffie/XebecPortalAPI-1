using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.Shared.Security
{
    public class LoginResult
    {
        public int AppUserId { get; set; }

        public string Message { get; set; } //used to Display a message to the user on the front end

        public string Email { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string JwtBearer { get; set; } //Nice to have, ensures full security of the person accessing the site

        public bool Success { get; set; }   //Used as a flag to indicate whether everything was a success or not

        public string Avatar { get; set; }

    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class RegisterModel : LoginModel
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Url { get; set; }
       // public string ImagePath { get; set; }  very nice to have
    }
}
