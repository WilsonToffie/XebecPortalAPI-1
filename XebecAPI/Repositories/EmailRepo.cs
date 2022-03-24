using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XebecAPI.IRepositories;
using XebecAPI.Shared.Security;

namespace XebecAPI.Repositories
{
    public class EmailRepo : IEmailRepo
    {
		HttpClient client = new HttpClient();
		public async Task<bool> ConfrimRegisterKey(AppUser user, string stringUrl)
		{

			try
			{

				EmailModel model = new EmailModel()
				{
					Id = user.Id.ToString(),
					ToEmail = user.Email,
					ToName = user.Name,
					PlainText = $@" Hi there {user.Name}, 

Please note that your key is {user.UserKey}. 

You can use this link to insert the key {stringUrl}

If you have any questions, please email admin.

Regards, 
Xebec Team",
					Subject = "Registration Confirmation key"
				};

				var emailSending = await SendEmail(model);

				if (emailSending)
					return true;
				return false;
				
			}
			catch (Exception)
			{

				return false;
			}
		}

        public async Task<bool> ForgotPasswordKey(AppUser user, string stringUrl)
		{
            try
            {
				EmailModel model = new EmailModel()
				{
					Id = user.Id.ToString(),
					ToEmail = user.Email,
					ToName = user.Name,
					PlainText = $@" Hi there {user.Name}, 

Please note that your key is {user.UserKey}. 

You can use this link to insert the key {stringUrl}

If you have any questions, please email admin.

Regards, 
Xebec Team",
					Subject = "Forgot Password key"
				};

				var emailSending = await SendEmail(model);

				if (emailSending)
					return true;
				return false;
			}
            catch (Exception)
            {

				return false;
            }
        }
        public async Task PowerAutomateAsync(AppUser mod, string URL)
        {
			PowerAutomate automate = new PowerAutomate()
			{
				Name = mod.Name,
				Surname = mod.Surname,
				Email = mod.Email,
				Role = mod.Role,
				UserKey = mod.UserKey,
				Link = URL,
				AuthorizerEmail = "mltivi001@myuct.ac.za"
			};
			var jsonInString = JsonConvert.SerializeObject(automate);
			using (var msg = await client.PostAsync("https://prod-223.westeurope.logic.azure.com:443/workflows/fa4c087fb4bc4ee6af54b07047ca6f57/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=doWY1Jeit9AC3MhFltbcskJ9J5ygBO9nZ_8BJEe5hPE", new StringContent(jsonInString, Encoding.UTF8, "application/json"), System.Threading.CancellationToken.None))
			{
				if (msg.IsSuccessStatusCode)
				{

				}
			}
		}

        public async Task<bool> SendAdminNotification(AppUser user, string stringUrl)
        {
			try
			{
				EmailModel model = new EmailModel()
				{
					Id = Guid.NewGuid().ToString(),
					ToEmail = "iviwe@nebula.co.za",
					ToName = "Iviwe Malotana",
					PlainText = $@" Hi there, 

Please note that there is a new HR registration on the site.

First Name {user.Name}
Surname {user.Surname}
Email {user.Email}

This person currently does not have access to the site. Please confirm that they are able to access the site by clicking the link below:

{stringUrl}

You can contact the person for more information if needed.

Regards, 
Xebec Team",
					Subject = "New HR admin request"
				};

				var emailSending = await SendEmail(model);

				if (emailSending)
					return true;
				return false;
			}
			catch (Exception)
			{

				return false;
			}
		}

        private async Task<bool> SendEmail(EmailModel model)
        {
			var jsonInString = JsonConvert.SerializeObject(model);
			using (var msg = await client.PostAsync("https://mailingservice2022.azurewebsites.net/api/email/sendgrid", new StringContent(jsonInString, Encoding.UTF8, "application/json"), System.Threading.CancellationToken.None))
			{
				if (msg.IsSuccessStatusCode)
				{
					return true;
				}
			}
			return false;
		}

		public class PowerAutomate: RegisterModel
        {

            public string UserKey { get; set; }
            public string Link { get; set; }

            public string AuthorizerEmail { get; set; }

		}
    }
}
