using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.Shared.Security
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserKey { get; set; }
        public bool Registered { get; set; } = false;
        public int LinkVisits { get; set; }
        public string? ImageUrl { get; set; }

        public List<Application> Applications { get; set; }

        public AppUser(int id, string email, string role, string name, string surname, string imageurl)
        {
            this.Id = id;
            this.Email = email;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
            this.ImageUrl = imageurl;
        } //Used for LoginResult

        public AppUser(int id, string email, string role, string name, string surname)
        {
            this.Id = id;
            this.Email = email;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
        } //Used for registration

        public AppUser(int id, string email, string role)
        {
            this.Id = id;
            this.Email = email;
            this.Role = role;
        }

        public AppUser(string email, string PasswordHash)
        {
            this.Email = email;
            this.PasswordHash = PasswordHash;
        } //used for login process

        public AppUser()
        {
            
        }


    }
}
