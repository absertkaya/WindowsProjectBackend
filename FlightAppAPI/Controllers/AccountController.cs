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
        public async Task<ActionResult> Login(LoginDTO model)
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
                        ApplicationUser appUser = _userRepository.GetUserBy(model.Email);
                        PassengerDTO passengerDTO;
                        if (appUser.Type.Equals(UserType.PASSENGER)) passengerDTO = PassengerDTO.FromPassenger((Passenger) appUser);
                        else passengerDTO = PassengerDTO.FromStaff((Staff) appUser);
                        passengerDTO.Token = token;
                        return Created("", passengerDTO);
                    }
                }
                return BadRequest("Invalid login credentials");
            }
            catch (Exception e) { return BadRequest(e.Message); }
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
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}