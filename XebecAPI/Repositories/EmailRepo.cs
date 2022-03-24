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

First Name: {user.Name}
Surname: {user.Surname}
Email: {user.Email}

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
    }
}
