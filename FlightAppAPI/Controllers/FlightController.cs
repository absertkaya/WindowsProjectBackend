using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using FlightAppAPI.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightAppAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FlightController : ControllerBase
    {
        #region Init
        private readonly IApplicationUserRepository _userRepository;
        private readonly IFlightRepository _flightRepository;

        public FlightController(
            IApplicationUserRepository userRepository,
            IFlightRepository flightRepository)
        {
            _userRepository = userRepository;
            _flightRepository = flightRepository;
        }
        #endregion

        // GET: api/Flight/{id}
        /// <summary>
        /// Get the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: the flight</returns>
        [HttpGet("{id}")]
        public ActionResult GetFlightBy(int id)
        {
            try
            {
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                if (user is null || !user.Type.Equals(UserType.STAFF)) return Unauthorized();
                Flight flight = _flightRepository.GetFlightBy(id);
                if (flight is null) return NotFound();

                return Ok(FlightDTO.FromFlight(flight));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Flight/Detail/{id}
        /// <summary>
        /// Get the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: the flight</returns>
        [HttpGet("detail/{id}")]
        public ActionResult GetFlightDetailBy(int id)
        {
            try
            {
                Flight flight = _flightRepository.GetFlightDetailBy(id);
                if (flight is null) return NotFound();
                return Ok(FlightMinimalDTO.FromFlight(flight));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Flight/friends/{id}
        /// <summary>
        /// Get the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: the flight</returns>
        [HttpGet("friends/{flightId}")]
        public ActionResult GetFriends(int flightId)
        {
            try
            {
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                IList<Passenger> pass = _flightRepository.GetFriends(flightId, user.Id);
                if (pass is null) return NotFound();
                return Ok(pass.Select(FriendDTO.FromPassenger));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Flight/friends/{id}
        /// <summary>
        /// Get the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: the flight</returns>
        [HttpGet("messages/{friendId}")]
        public ActionResult GetMessages(int friendId)
        {
            try
            {
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                IList<Message> messages = _flightRepository.GetMessages(user.Id, friendId);
                if (messages is null) return NotFound();
                return Ok(messages.Select(MessageDTO.FromMessage));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Flight/friends/{id}
        /// <summary>
        /// Get the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: the flight</returns>
        [HttpPost("messages/{friendId}")]
        public ActionResult PostMessage(int friendId, MessageDTO dto)
        {
            try
            {
                Passenger user = (Passenger)_userRepository.GetUserBy(User.Identity.Name);
                Passenger friend = (Passenger)_userRepository.GetUserById(friendId);
                Message message = new Message
                {
                    Content = dto.Content,
                    Sender = user,
                    Receiver = friend,
                    Timestamp = DateTime.Now
                };
                user.SentMessages.Add(message);
                friend.ReceivedMessages.Add(message);
                _flightRepository.SaveChanges();
                return Created("", MessageDTO.FromMessage(message));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }


        // GET: api/Flight/{id}/get_seats
        /// <summary>
        /// Get the seats from the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: the seats</returns>
        [HttpGet("{id}/get_seats")]
        public ActionResult GetSeatsBy(int id)
        {
            
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                if (user is null || !user.Type.Equals(UserType.STAFF)) return Unauthorized();
                IList<Seat> seats = _flightRepository.GetSeatsBy(id);
                if (seats is null) return NotFound();

                return Ok(seats.Select(SeatDTO.FromSeat));
            
        }

        // GET: api/Flight/{id}/get_passengers
        /// <summary>
        /// Get the passengers from the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: the passengers</returns>
        [HttpGet("{id}/get_passengers")]
        public ActionResult GetPassengersBy(int id)
        {

            ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
            if (user is null || !user.Type.Equals(UserType.STAFF)) return Unauthorized();
            IList<Passenger> passengers = _flightRepository.GetPassengersBy(id);
            if (passengers is null) return NotFound();

            return Ok(passengers.Select(PassengerDTO.FromPassenger));

        }

        // POST: api/Flight/move_passenger/{id}/{id2}
        /// <summary>
        /// Switch the passengers on the specified seats
        /// </summary>
        /// <param name="id">The first seat</param>
        /// <param name="id2">The second seat</param>
        /// <returns>200</returns>
        [HttpPost("move_passenger/{id}/{id2}")]
        public ActionResult MovePassenger(int id, int id2)
        {
            try
            {
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                if (user is null || !user.Type.Equals(UserType.STAFF)) return Unauthorized();

                _flightRepository.MovePassenger(id, id2);
                _flightRepository.SaveChanges();

                return Ok();
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}