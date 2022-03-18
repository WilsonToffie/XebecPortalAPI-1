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

		public async Task<int> CheckExistingUser(string email)
        {
            try
            {
				var user = await unitOfWork.AppUsers.GetT(q => q.Email.Equals(email));// WATCH OUT
				if (user != null)
				{
					return user.Id;
				}
				return 0;
			}
            catch (Exception)
            {

				return -1;
            }
        }

		public async Task<AppUser> AssignneyKey(AppUser user)
		{
			try
			{
					string key = Guid.NewGuid().ToString().Substring(0, 6); //create new key
					user.UserKey = key;
					unitOfWork.AppUsers.Update(user);
					await unitOfWork.Save();
				return user;
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
					return new AppUser()
					{
						Id = 0
					};

				//hash the password provided
				string hashedPassword = CreateHash(password);

				AppUserDTO appUserDto = new AppUserDTO(email, hashedPassword, role, name, surname);

                var user = mapper.Map<AppUser>(appUserDto);
                if (role == "Candidate")
                {
					user.Registered = true;
				}
                else
                {
					string key = Guid.NewGuid().ToString().Substring(0, 6); //create new key
					user.UserKey = key;
				}
				//Saving stuff
				await unitOfWork.AppUsers.Insert(user);
                await unitOfWork.Save();

				// return user
				return user;

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

				var userId = await CheckExistingUser(email);
				if (userId < 1)
					return null;

				var user = await unitOfWork.AppUsers.GetT(q => q.Email.Equals(email));// WATCH OUT
				var result = mapper.Map<AppUserDTO>(user);

				if (!result.PasswordHash.Equals(CreateHash(password)))
					return null;

				return new AppUser(user.Id, email, result.Role, result.Name, result.Surname, result.ImageUrl);
			}
			catch (Exception)
			{

				return null;
			}
		}

		public async Task<AppUser> UpdateUserModified(string email, string password)
		{
			try
			{
				if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
					return null;

				var user = await unitOfWork.AppUsers.GetT(q => q.Email.Equals(email));
				var result = mapper.Map<AppUserDTO>(user);
				result.PasswordHash = password;

				unitOfWork.AppUsers.Update(user);
				await unitOfWork.Save();

				return new AppUser(user.Id, email, result.Role, result.Name, result.Surname, result.ImageUrl);
			}
			catch (Exception)
			{

				return null;
			}
		}
	}
}
