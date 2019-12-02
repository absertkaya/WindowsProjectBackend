using System;
using System.Collections.Generic;
using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightAppAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class EntertainmentController : ControllerBase
    {
        #region Init
        private readonly IEntertainmentRepository _entertainmentRepository;

        public EntertainmentController(IEntertainmentRepository entertainmentRepository)
        {
            _entertainmentRepository = entertainmentRepository;
        }
        #endregion

        // GET: api/Entertainment/get_movies
        /// <summary>
        /// Get the movies
        /// </summary>
        /// <returns>200: the movies</returns>
        [AllowAnonymous]
        [HttpGet("get_movies")]
        public ActionResult GetMovies()
        {
            try
            {
                IList<Movie> movies = _entertainmentRepository.GetMovies();
                if (movies is null) return NotFound();

                return Ok(movies);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}