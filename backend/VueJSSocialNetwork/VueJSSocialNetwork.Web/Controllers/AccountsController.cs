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
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace VueJSSocialNetwork.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private IConfiguration _config;

        public AccountsController(UserManager<User> userManager, ApplicationDbContext appDbContext, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, IConfiguration config)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _appDbContext = appDbContext;
            _config = config;

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
                    LastName = model.LastName, Age = model.Age, PictureUrl = model.Photo.ToString()
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
        public async Task<IActionResult> Post([FromBody] CredentialsViewModel credentials)
        {
            var validator = new CredentialsViewModelValidator();
            var result = validator.Validate(credentials);
            if (!ModelState.IsValid || !result.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

            //var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
           var user = await _userManager.FindByEmailAsync(credentials.UserName);
           var tokenString = GenerateJsonWebToken(user);
           return new OkObjectResult(new { user = user, token = tokenString });
           
            
        }

        private string GenerateJsonWebToken(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtIssuerOptions:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["JwtIssuerOptions:Issuer"],
                    _config["JwtIssuerOptions:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }


        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByEmailAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
