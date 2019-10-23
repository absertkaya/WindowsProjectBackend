﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using FlightAppAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementRepository _announcementRepo;

        public AnnouncementController(IAnnouncementRepository announcementRepo)
        {
            _announcementRepo = announcementRepo;
        }

        [AllowAnonymous]
        [HttpGet("get_all")]
        public IEnumerable<AnnouncementDTO> GetAllAnnouncements()
        {
            IList<Announcement> announcements = _announcementRepo.GetAllAnnouncements();
            return announcements.Select(AnnouncementDTO.FromAnnouncement);
        }
    }
}