using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
                Staff user = _userRepository.GetStaffBy(User.Identity.Name);
                if (user is null) return Unauthorized();
                Flight flight = _flightRepository.GetFlightBy(id);
                if (flight is null) return NotFound();

                return Ok(flight);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Flight/{id}/get_orders
        /// <summary>
        /// Get the orders from the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <returns>200: the orders</returns>
        [HttpGet("{id}/get_orders")]
        public ActionResult GetOrdersBy(int id)
        {
            try
            {
                Staff user = _userRepository.GetStaffBy(User.Identity.Name);
                if (user is null) return Unauthorized();
                IList<Order> orders = _flightRepository.GetOrdersBy(id);
                if (orders is null) return NotFound();

                return Ok(orders);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Flight/get_products
        /// <summary>
        /// Get the products
        /// </summary>
        /// <returns>200: the products</returns>
        [HttpGet("get_products")]
        public ActionResult GetProducts()
        {
            try
            {
                IList<Product> products = _flightRepository.GetProducts();
                if (products is null) return NotFound();

                return Ok(products);
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
            try
            {
                Staff user = _userRepository.GetStaffBy(User.Identity.Name);
                if (user is null) return Unauthorized();
                IList<Seat> seats = _flightRepository.GetSeatsBy(id);
                if (seats is null) return NotFound();

                return Ok(seats);
            }
            catch (Exception e) { return BadRequest(e.Message); }
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
                Staff user = _userRepository.GetStaffBy(User.Identity.Name);
                if (user is null) return Unauthorized();

                _flightRepository.MovePassenger(id, id2);
                _flightRepository.SaveChanges();

                return Ok();
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // POST: api/Flight/{id}/place_order
        /// <summary>
        /// Place a new order on the specified flight
        /// </summary>
        /// <param name="id">The id of the flight</param>
        /// <param name="model">The order</param>
        /// <returns>200: the placed order</returns>
        [HttpPost("{id}/place_order")]
        public ActionResult PlaceOrder(int id, List<OrderLine> orderLines)
        {
            try
            {
                Passenger user = _userRepository.GetPassengerBy(User.Identity.Name);
                if (user is null) return Unauthorized();

                Order order = new Order { Customer = user, OrderLines = orderLines };
                _flightRepository.PlaceOrder(id, order);
                _flightRepository.SaveChanges();

                return Ok(order);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}