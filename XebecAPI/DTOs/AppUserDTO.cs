using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.DTOs
{
    public class AppUserDTO
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

        public AppUserDTO(string email, string PasswordHash, string role, string name, string surname)
        {
            this.Email = email;
            this.PasswordHash = PasswordHash;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
            LinkVisits = 0;
        }

        public AppUserDTO(int id, string email, string role)
        {
            this.Id = id;
            this.Email = email;
            this.Role = role;
        }

        public AppUserDTO(string email, string role, string passwordHash)
        {
            //this.Id = id;
            this.Email = email;
            this.Role = role;
            this.PasswordHash = passwordHash;
        }

        public AppUserDTO()
        {
            
        }


    }
}
