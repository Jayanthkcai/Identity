using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oauth_Google.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var authenticationProperties = new AuthenticationProperties { RedirectUri = Url.Action("Index", "Home") };
            return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);
        }

        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = Url.Action("Index", "Home") },
                       CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
