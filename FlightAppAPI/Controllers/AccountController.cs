using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using FlightAppAPI.DTOs;
using FlightAppAPI.Domain.IRepositories;
using FlightAppAPI.Domain;

namespace FlightAppAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AccountController : ControllerBase
    {
        #region Init
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IApplicationUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IApplicationUserRepository userRepository,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _config = config;
        }
        #endregion

        // POST: api/Account
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">The login details</param>
        /// <returns>201: JWT token</returns>
        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDTO model)
        {
            try
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        string token = GetToken(user);
                        return Created("", token);               
                    }
                }
                return BadRequest("Invalid login credentials");
            } catch(Exception e) { return BadRequest(e.Message); }
        }

        // POST: api/Announcement/register
        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="model">The user details</param>
        /// <returns>201: JWT token</returns>
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterDTO model)
        {
            try
            {
                IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
                Passenger appUser = new Passenger { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, BirthDate = model.BirthDate };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _userRepository.AddPassenger(appUser);
                    _userRepository.SaveChanges();
                    string token = GetToken(user);
                    return Created("", token);
                }
                return BadRequest("Could not register.");
            } catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Announcement/CheckAvailableUsername
        /// <summary>
        /// Checks if an email is available as username
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>200: True if email is available</returns>
        [HttpGet("checkusername")]
        public async Task<ActionResult<bool>> CheckAvailableUserName(string email)
        {
            try
            {
                IdentityUser user = await _userManager.FindByNameAsync(email);
                return Ok(user == null);
            } catch (Exception e) { return BadRequest(e.Message); }
        }

        #region Functions
        private string GetToken(IdentityUser user)
        {
            // Create the token
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              null, null,
              claims,
              expires: DateTime.Now.AddMinutes(90),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}