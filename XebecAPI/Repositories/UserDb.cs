using AutoMapper;
using XebecAPI.Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.IRepositories;
using XebecAPI.DTOs;

namespace XebecAPI.Repositories
{
    public class UserDb : IUserDb
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserDb(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public static string CreateHash(string password)
        {
            var salt = "997eff51db1544c7a3c2ddeb2053f052";
            var md5 = new HMACMD5(Encoding.UTF8.GetBytes(salt + password));
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return System.Convert.ToBase64String(data);

        }


        public async Task<AppUser> AddUser(string email, string password, string role)
        {
			try
			{
				if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
					return null;

				//store in db
				string hashedPassword = CreateHash(password);

				AppUserDTO appUserDto = new AppUserDTO(email, role, hashedPassword);

				var user = mapper.Map<AppUser>(appUserDto);
				await unitOfWork.AppUsers.Insert(user);
				await unitOfWork.Save();

				// return user
				return new AppUser(user.Id, email, role);

			}
			catch
			{
				return null;
			}
		}

		public async Task<AppUser> AuthenticateUser(string email, string password)
        {
            try
            {
				if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
					return null;

				var user = await unitOfWork.AppUsers.GetT(q => q.Email.Equals(email));// WATCH OUT
				var result = mapper.Map<AppUser>(user);

				if (!result.PasswordHash.Equals(CreateHash(password)))
					return null;

				return new AppUser(user.Id, email, result.Role);
			}
            catch (Exception)
            {

				return null;
            }
		}

		public async Task<AppUser> AddUserModified(string email, string password, string role, string name, string surname)
		{
			try
			{
				if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
					return null;

				//hash the password provided
				string hashedPassword = CreateHash(password);

				AppUserDTO appUserDto = new AppUserDTO(email, role, hashedPassword, name, surname);

                var user = mapper.Map<AppUser>(appUserDto);
				user.Registered = true;
                await unitOfWork.AppUsers.Insert(user);
                await unitOfWork.Save();
                //Saving stuff

                // return user
                return new AppUser(user.Id, email, role, name, surname); //get it done after saving

			}
			catch
			{
				return null;
			}
		}

		public async Task<AppUser> AuthenticateUserModified(string email, string password)
		{
			try
			{
				if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
					return null;

				var user = await unitOfWork.AppUsers.GetT(q => q.Email.Equals(email));// WATCH OUT
				var result = mapper.Map<AppUserDTO>(user);

				if (!result.PasswordHash.Equals(CreateHash(password)))
					return null;

				return new AppUser(user.Id, email, result.Role, result.Name, result.Surname);
			}
			catch (Exception)
			{

				return null;
			}
		}
	}
}
