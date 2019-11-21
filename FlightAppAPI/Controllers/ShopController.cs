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
    public class ShopController : ControllerBase
    {
        #region Init
        private readonly IApplicationUserRepository _userRepository;
        private readonly IShopRepository _shopRepository;

        public ShopController(
            IApplicationUserRepository userRepository,
            IShopRepository shopRepository)
        {
            _userRepository = userRepository;
            _shopRepository = shopRepository;
        }
        #endregion

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
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                if (user is null || !user.Type.Equals(UserType.STAFF)) return Unauthorized();
                IList<Order> orders = _shopRepository.GetOrdersBy(id);
                if (orders is null) return NotFound();
                return Ok(orders.Select(OrderDTO.FromOrder));
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // GET: api/Flight/get_products
        /// <summary>
        /// Get the products
        /// </summary>
        /// <returns>200: the products</returns>
        [AllowAnonymous]
        [HttpGet("get_products")]
        public ActionResult GetProducts()
        {
            try
            {
                IList<Product> products = _shopRepository.GetProducts();
                if (products is null) return NotFound();

                return Ok(products);
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
        [HttpPost("create_order/{id}")]
        public ActionResult PlaceOrder(int id, PlaceOrderDTO placeOrder)
        {
            try
            {
                ApplicationUser user = _userRepository.GetUserBy(User.Identity.Name);
                if (user is null || !user.Type.Equals(UserType.PASSENGER)) return Unauthorized();

                Order order = new Order();
                placeOrder.OrderLines.ToList().ForEach(ol =>
                {
                    Product prod = _shopRepository.GetProductById(ol.ProductId);
                    OrderLine line = new OrderLine(prod, ol.Amount);
                    order.OrderLines.Add(line);
                });
                order.Customer = (Passenger)user;
                _shopRepository.PlaceOrder(id, order);
                _shopRepository.SaveChanges();

                return Ok(OrderDTO.FromOrder(order));
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}