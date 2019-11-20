using System;
using System.Collections.Generic;
using System.Linq;
using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using FlightAppAPI.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightAppAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AnnouncementController : ControllerBase
    {
        #region Init
        private readonly IApplicationUserRepository _userRepository;
        private readonly IFlightRepository _flightRepository;

        public AnnouncementController(
            IApplicationUserRepository userRepository,
            IFlightRepository flightRepository)
        {
            _userRepository = userRepository;
            _flightRepository = flightRepository;
        }
        #endregion

        // GET: api/Announcement/get_by_flight/{id}
        /// <summary>
        /// Get all announcements of the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: all announcements of the specified flight</returns>
        [HttpGet("get_by_flight/{id}")]
        public ActionResult<IEnumerable<AnnouncementDTO>> GetAnnouncementsByFlight(int id)
        {
            try
            {
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                IList<Announcement> announcements = _flightRepository.GetAnnouncementsBy(id, user);
                return Ok(announcements.Select(AnnouncementDTO.FromAnnouncement));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpGet("get_personal_by_flight/{flightId}/{passengerId}")]
        public ActionResult<IEnumerable<AnnouncementDTO>> GetPersonalAnnouncementsByFlight(int flightId, int passengerId)
        {
            try
            {
                Passenger passenger = (Passenger)_userRepository.GetUserById(passengerId);
                IList<Announcement> announcements = _flightRepository.GetPersonalAnnouncementsBy(flightId, passenger);
                return Ok(announcements.Select(AnnouncementDTO.FromAnnouncement));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // POST: api/Announcement
        /// <summary>
        /// Add the Announcement with the given properties
        /// </summary>
        /// <param name="announcementDTO">The announcement details</param>
        /// <param name="id">The id of the flight</param>
        /// <returns>201: created announcement</returns>
        [HttpPost("create_by_flight/{id}")]
        public ActionResult CreateAnnouncement(AnnouncementCreateDTO announcementDTO, int id)
        {
            try
            {
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                if (user is null || !user.Type.Equals(UserType.STAFF)) return Unauthorized();

                Passenger receiver = null;
                if (announcementDTO.PassengerId != null)
                {
                    receiver = (Passenger)_userRepository.GetUserById((int)announcementDTO.PassengerId);
                }

                Announcement announcement = new Announcement
                {
                    Title = announcementDTO.Title,
                    Content = announcementDTO.Content,
                    Sender = (Staff)user,
                    Receiver = receiver
                    
                };
                _flightRepository.CreateAnnouncement(id, announcement);
                _flightRepository.SaveChanges();
                return Created("", AnnouncementDTO.FromAnnouncement(announcement));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}