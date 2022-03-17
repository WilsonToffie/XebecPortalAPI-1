using AutoMapper;
using XebecAPI.Shared.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.IRepositories;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace XebecAPI.Controllers
{
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserDb userDb;
		private readonly IUnitOfWork unitOfWork;

		public AuthController(IUserDb userDb, IUnitOfWork unitOfWork)
		{
			this.userDb = userDb;
			this.unitOfWork = unitOfWork;
		}

		private string CreateJWT(AppUser user)
		{
			var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("THIS IS THE SECRET KEY"));
			// NOTE: SAME KEY AS USED IN Startup.cs FILE

			var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

			var claims = new[] // NOTE: could also use List<Claim> here
			{
				new Claim(ClaimTypes.Name, user.Email), // NOTE: this will be the "User.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, user.Email) 
				// NOTE: this could a unique ID assigned to the user by a database
			};

			var token = new JwtSecurityToken(issuer: "domain.com", audience: "domain.com", claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}



		[HttpPost]
		[Route("api/auth/register")]
		public async Task<LoginResult> Post([FromBody] RegisterModel reg)
		{

			AppUser newuser = await userDb.AddUser(reg.Email, reg.Password, reg.Role);

			if (newuser != null)

				return new LoginResult
				{
					Message = "Registration successful.",
					JwtBearer = CreateJWT(newuser),
					Email = reg.Email,
					Role = reg.Role,
					Success = true,
					AppUserId = newuser.Id
				};

			return new LoginResult { Message = "User already exists.", Success = false };

		}

		[HttpPost]
		[Route("api/auth/registernew")]
		public async Task<LoginResult> Register([FromBody] RegisterModel reg)
		{
			try
			{
				var user = await unitOfWork.AppUsers.GetT(q => q.Email.Equals(reg.Email));// WATCH OUT
				if (user != null)
				{
					return new LoginResult { Message = "User already exists.", Success = false };
				}
				//Add user to db if it doesn't return null
				AppUser newuser = await userDb.AddUserModified(reg.Email, reg.Password, reg.Role, reg.Name, reg.Surname);
                if (newuser.Id == 0)
                {

					return new LoginResult { Message = "Email or password is empty", Success = false };
				}
				if (newuser != null && newuser.Id != 0)
				{
					bool emailKey = false;
					if (newuser.Role != "Candidate")
                    {
						 emailKey = await RegisterKey(newuser);
					}
                    if (!emailKey)
                    {
						return new LoginResult { Message = "failed to send email", Success = false };
					}
					else
                    {
						return new LoginResult
						{
							Message = "Registration successful",
							//JwtBearer = CreateJWT(newuser),// fix
							Email = newuser.Email,
							Role = newuser.Role,
							Name = newuser.Name,
							Surname = newuser.Surname,
							Success = true,
							AppUserId = newuser.Id
						};
					}
					
				}
		
				return new LoginResult { Message = "Failed to register user.", Success = false };

			}
			catch
			{
				return new LoginResult { Message = "Something went wrong with your request. Please reload and try again.", Success = false };
			}

		}

		[HttpPost]
		[Route("api/auth/login")]
		public async Task<LoginResult> Post([FromBody] LoginModel log)
		{
			AppUser user = await userDb.AuthenticateUser(log.Email, log.Password);

			if (user != null)
				return new LoginResult
				{
					AppUserId = user.Id,//<-newly added
					Message = "Login successful.",
					JwtBearer = CreateJWT(user),
					Email = log.Email,
					Role = user.Role,
					Success = true
				};

			return new LoginResult { Message = "User/password not found.", Success = false };

		}

		[HttpPost]
		[Route("api/auth/loginnew")]
		public async Task<LoginResult> Login([FromBody] LoginModel log)
		{
			AppUser user = await userDb.AuthenticateUserModified(log.Email, log.Password);

			if (user != null)
				return new LoginResult
				{
					AppUserId = user.Id,//<-newly added
					Message = "Login successful.",
					//JwtBearer = CreateJWT(user),
					Email = user.Email,
					Role = user.Role,
					Name = user.Name,
					Surname = user.Surname,
					
					Success = true,
				};

			return new LoginResult { Message = "User/password not found.", Success = false };

		}

		[HttpPost("key")]
		public async Task<bool> RegisterKey([FromBody] AppUser user)
        {

            try
            {
				HttpClient client = new HttpClient();
				EmailModel model = new EmailModel()
				{
					Id = user.Id.ToString(),
					ToEmail = user.Email,
					ToName = user.Name,
					PlainText = $" Hi there {user.Name}, \n Please note that your key is {user.UserKey}. If you have any questions, please email admin, \n Regards, Xebec Team",
					Subject = "Registration Confirmation key"
				};
				
				var jsonInString = JsonConvert.SerializeObject(model);
				using (var msg = await client.PostAsync("https://mailingservice2022.azurewebsites.net/api/email/sendgrid", new StringContent(jsonInString, Encoding.UTF8, "application/json"), System.Threading.CancellationToken.None))
                {
					unitOfWork.AppUsers.Update(user);
					await unitOfWork.Save();
					if (msg.IsSuccessStatusCode)
                    {
						return true;
					}
                }
				return false;
				
			}
            catch (Exception)
            {

				return false;
			}
			
		}

		[HttpPost("keyConfirm")]
		public async Task<bool> ConfirmrKey([FromBody] AppUser user)
		{

			try
			{
				AppUser newuser = await unitOfWork.AppUsers.GetT(x => x.Id == user.Id);

                if (newuser != null)
                {
                    if (newuser.UserKey == user.UserKey)
                    {
						return true;
                    } 
				}
				return false;

			}
			catch (Exception)
			{

				return false;
			}

		}

	}
}
