using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace Dotnet5MvcOkta
{

    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn([FromForm] string sessionToken)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                // var properties = new AuthenticationProperties();
                // properties.Items.Add("sessionToken", sessionToken);
                // properties.RedirectUri = "/Home/";

                // return Challenge(properties, OktaDefaults.MvcAuthenticationScheme);
                return Challenge(OpenIdConnectDefaults.AuthenticationScheme);

            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            return new SignOutResult(
                new[]
                {
                     OktaDefaults.MvcAuthenticationScheme,
                     CookieAuthenticationDefaults.AuthenticationScheme,
                },
                new AuthenticationProperties { RedirectUri = "/Home/" });
        }
    }

}