using XebecAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared.Security;

namespace XebecAPI.IRepositories
{
    public interface IUserDb
    {
        Task<AppUser> AuthenticateUser(string email, string password);

        Task<AppUser> AddUser(string email, string password, string role);

        Task<AppUser> AddUserModified(string email, string password, string role, string name, string surname);

        Task<AppUser> AuthenticateUserModified(string email, string password);
    }
}
