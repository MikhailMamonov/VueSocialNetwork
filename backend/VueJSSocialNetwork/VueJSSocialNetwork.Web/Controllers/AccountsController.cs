//using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VueJSSocialNetwork.Web.Helpers;
using VueJSSocialNetwork.Web.Models;
using VueJSSocialNetwork.Web.ViewModels;

using VueJSSocialNetwork.Data;
using VueJSSocialNetwork.Data.Entities;
using VueJSSocialNetwork.Web.Auth;
using VueJSSocialNetwork.Web.ViewModels.Validations;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace VueJSSocialNetwork.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationSettings _appSettings;


        public AccountsController(UserManager<User> userManager, ApplicationDbContext appDbContext,
            IOptions<ApplicationSettings> appSettings )
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;


        }

        // POST api/accounts/register
        /// <summary>
        /// Register new user 
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegistrationViewModel model)
        {
            try
            {
                // simulate slightly longer running operation to show UI state change
                await Task.Delay(250);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = new User()
                {
                    UserName = model.Username, Email = model.Email, FirstName = model.FirstName,
                    LastName = model.LastName, Age = model.Age??0, PictureUrl = model.Photo
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                    return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                return new OkObjectResult("Account created");
            }
            catch (Exception e)
            {
                throw;
            }
        }


        /// <summary>
            /// Login User.
            /// </summary>
            // POST api/auth/login
            [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] CredentialsViewModel model)
        {
            try
            {
                //var validator = new CredentialsViewModelValidator();
                //var validateResult = validator.Validate(credentials);
                //if (!ModelState.IsValid || !validateResult.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}

                //var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
                //if (identity == null)
                //{
                //    return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
                //}


                //var user = await _userManager.FindByEmailAsync(credentials.UserName);
                //if (user == null)
                //{
                //    return BadRequest(ModelState);
                //}



                //var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });

                //return new OkObjectResult(new { user, token = jwt });

                var user = await _userManager.FindByEmailAsync(model.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserID",user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = 
                            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), 
                                SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return new OkObjectResult(new { user, token });
                }
                else
                    return BadRequest(new { message = "Username or password is incorrect." });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }

        


        //private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        //{
        //    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        //        return await Task.FromResult<ClaimsIdentity>(null);

        //    // get the user to verifty
        //    var userToVerify = await _userManager.FindByEmailAsync(userName);

        //    if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

        //    // check the credentials
        //    if (await _userManager.CheckPasswordAsync(userToVerify, password))
        //    {
        //        return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
        //    }

        //    // Credentials are invalid, or account doesn't exist
        //    return await Task.FromResult<ClaimsIdentity>(null);
        //}
    }
}
