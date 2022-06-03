using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.IRepositories;

namespace XebecAPI.Controllers.Security
{
    [ApiController]
    [AllowAnonymous, Route("account")]
    public class AccountController : Controller
    {
        private readonly IUserDb userDb;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailRepo emailrepo;

        public AccountController(IUserDb userDb, IUnitOfWork unitOfWork, IEmailRepo emailrepo)
        {
            this.userDb = userDb;
            this.unitOfWork = unitOfWork;
            this.emailrepo = emailrepo;
        }

        [HttpGet("googleSignIn")]
        public async Task GoogleSignIn()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
            new AuthenticationProperties { RedirectUri = "/main" });// 

        }

        [HttpGet]
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme); 
        }

        [HttpGet]
        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

            return Json(claims);

        }
    }
}
