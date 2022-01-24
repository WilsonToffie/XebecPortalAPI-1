using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.Shared.Security
{
    public class AppUserTwoDTO
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Key { get; set; }
        public bool Registered { get; set; } = false;
        public int LinkVisits { get; set; }

        //used for registration
        public AppUserTwoDTO(string email, string PasswordHash, string role, string name, string surname)
        {
            this.Email = email;
            this.PasswordHash = PasswordHash;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
            LinkVisits = 0;
        }
        public AppUserTwoDTO(string email, string PasswordHash)
        {
            this.Email = email;
            this.PasswordHash = PasswordHash;
        }

        public AppUserTwoDTO()
        {

        }


    }
}
