using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth_Azure.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "AzureAD");
        }

        public IActionResult Logout()
        {
          //  var callbackUrl = Url.Action("SignedOut", "Account", values: null, protocol: Request.Scheme);
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = "/"
            };

            // Sign out from AzureAD and Cookies authentication schemes
            return SignOut(authenticationProperties, AzureADDefaults.AuthenticationScheme, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult SignedOut()
        {
            return RedirectToAction("Index", "Landing");
        }
    }
}
