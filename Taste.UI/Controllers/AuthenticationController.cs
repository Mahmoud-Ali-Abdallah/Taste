using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Taste.SharedModels.Models;
using Taste.Utility;

namespace Taste.UI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly HttpClient _client;

        public AuthenticationController(HttpClient httpClient)
        {
            _client = httpClient;
        }

        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] string userName, [FromQuery] string pwd,
            [FromQuery] string url)
        {
            ApplicationUserModel user = new ApplicationUserModel()
            {
                UserName = userName,
                Password = pwd
            };

            var res = (await _client.PostAsJsonAsync<ApplicationUserModel>($"Authentication/login", user));

            // Check if res != null 
            var response = res.Content.ReadFromJsonAsync<Response<ApplicationUserModel>>().Result;

            if (response == null)
            {

                return Redirect("");
            }
            if (response.StatusCode == Utility.StatusCode.UnAuthorized)
            {
                return Redirect("/Account/login/1");

            }


            var usersClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , userName),
                    new Claim(ClaimTypes.Email, "admin@eCommerce.com"),
                    new Claim(ClaimTypes.HomePhone , "123456789")
                };

                if (response.Data.Roles != null && response.Data.Roles.Count != 0)
                {
                    foreach (var role in response.Data.Roles)
                    {
                        usersClaims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    
                }

                var userIdentity = new ClaimsIdentity(usersClaims, "Taste.CookieAuth");

                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync("Taste.CookieAuth", userPrincipal);
           

            return Redirect("/");
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/outstandingorders");
        }
    }
}
