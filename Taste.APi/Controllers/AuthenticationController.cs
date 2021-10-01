using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Taste.Models;
using Taste.Models.DTO.Account;
using Taste.SharedModels.Models;
using Taste.Utility;

namespace Taste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public AuthenticationController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            IConfiguration configuration
            )
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._emailSender = emailSender;
            this._configuration = configuration;
        }

        

        [HttpPost]
        [Route("login")]
        public async Task<Response<ApplicationUserModel>> Login([FromBody] LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // get user roles

                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                // Create token for user
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                ApplicationUserModel ApplicationUserModel = new ApplicationUserModel()
                {
                    FullName = user.FirstName + "" + user.LastName,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Roles = userRoles
                };

                return new Response<ApplicationUserModel>
                {
                    Status = "Succes",
                    Message = "Login successfully",
                    StatusCode = Utility.StatusCode.Ok,
                    Data = ApplicationUserModel,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            return new Response<ApplicationUserModel> 
            { 
                Status = "Fail",
                Message = "Invalid User name or password. Please try again.",
                StatusCode = Utility.StatusCode.UnAuthorized
            };
        }

        [HttpPost]
        [Route("register")]
        public async Task<Response<ApplicationUserModel>> Register([FromBody] RegisterDTO model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return new Response<ApplicationUserModel>
                {
                    Status = "Error",
                    Message = "User already exists!",
                    StatusCode = Utility.StatusCode.Confilict
                };

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName, 
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new Response<ApplicationUserModel>
                {
                    Status = "Error",
                    Message = "User creation failed! Please check user details and try again.",
                    StatusCode = Utility.StatusCode.InternalServerError
                };
            
            LoginDTO login = new LoginDTO(){
                UserName = model.Email,
                Password = model.Password
            };

            // Login to get token
            var res = await Login(login);

            return new Response<ApplicationUserModel>
            {
                Status = "Success",
                Message = "User created successfully!",
                StatusCode = Utility.StatusCode.Created,
                Token = res.Token,
                Data = res.Data
                

            }; 
        }

        /*[HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDTO model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }*/


    }
}
