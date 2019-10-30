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
        private readonly IAnnouncementRepository _announcementRepo;
        private readonly IApplicationUserRepository _userRepository;

        public AnnouncementController(
            IAnnouncementRepository announcementRepo,
            IApplicationUserRepository userRepository)
        {
            _announcementRepo = announcementRepo;
            _userRepository = userRepository;
        }
        #endregion

        // GET: api/Announcement/get_all
        /// <summary>
        /// Get all announcements
        /// </summary>
        /// <returns>200: all announcements</returns>
        [HttpGet("get_all")]
        public ActionResult<IEnumerable<AnnouncementDTO>> GetAllAnnouncements()
        {
            try
            {
                IList<Announcement> announcements = _announcementRepo.GetAllAnnouncements();
                return Ok(announcements.Select(AnnouncementDTO.FromAnnouncement));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Announcement/{id}
        /// <summary>
        /// Get the Announcement with the given id
        /// </summary>
        /// <returns>200: requested announcement</returns>
        [HttpGet("{id}")]
        public ActionResult<AnnouncementDTO> GetAnnouncementById(int id)
        {
            try
            {
                Announcement announcement = _announcementRepo.GetById(id);
                if (announcement is null) return NotFound();
                return Ok(AnnouncementDTO.FromAnnouncement(announcement));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // POST: api/Announcement
        /// <summary>
        /// Add the Announcement with the given properties
        /// </summary>
        /// <param name="announcementDTO">The announcement details</param>
        /// <returns>201: created announcement</returns>
        [HttpPost]
        public ActionResult CreateAnnouncement(AnnouncementCreateDTO announcementDTO)
        {
            try
            {
                Staff user = _userRepository.GetStaffBy(User.Identity.Name);
                if (user is null) return Unauthorized();

                Announcement announcement = new Announcement
                {
                    Title = announcementDTO.Title,
                    Content = announcementDTO.Content
                };
                _announcementRepo.Add(announcement, user);
                return Created("", AnnouncementDTO.FromAnnouncement(announcement));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // DELETE: api/Announcement
        /// <summary>
        /// Delete the Announcement with the given id
        /// </summary>
        /// <returns>200: deleted announcement</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteAnnouncement(int id)
        {
            try
            {
                Staff user = _userRepository.GetStaffBy(User.Identity.Name);
                Announcement announcement = _announcementRepo.GetById(id);
                if (announcement is null) return NotFound();

                _announcementRepo.Delete(announcement);
                return Ok(AnnouncementDTO.FromAnnouncement(announcement));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}