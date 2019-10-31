using System;
using System.Collections.Generic;
using System.Linq;
using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using FlightAppAPI.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
                IList<Announcement> announcements = _flightRepository.GetAnnouncementsBy(id);
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
                Staff user = _userRepository.GetStaffBy(User.Identity.Name);
                if (user is null) return Unauthorized();

                Announcement announcement = new Announcement
                {
                    Title = announcementDTO.Title,
                    Content = announcementDTO.Content,
                    Sender = user
                };
                _flightRepository.CreateAnnouncement(id, announcement);
                _flightRepository.SaveChanges();
                return Created("", AnnouncementDTO.FromAnnouncement(announcement));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}