using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlightAppAPI.Data.Repositories
{
    public class ShopRepository : IShopRepository
    {
        #region Init
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Flight> _flights;

        public ShopRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _flights = dbContext.Flights;
        }

        private IQueryable<Flight> Flights => _flights
            .Include(f => f.Announcements).ThenInclude(a => a.Sender)
            .Include(f => f.Orders).ThenInclude(o => o.OrderLines).ThenInclude(p => p.Product)
            .Include(f => f.Orders).ThenInclude(o => o.Customer).ThenInclude(p => p.Seat)
            .Include(f => f.Seats).ThenInclude(s => s.Passenger);
        #endregion

        public IList<Order> GetOrdersBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Orders;

        public Product GetProductById(int id) => _context.Products.FirstOrDefault(p => p.Id == id);

        public IList<Product> GetProducts() => _context.Products.ToList();

        public void HandleOrder(int order) => _context.Orders.FirstOrDefault(o => o.Id.Equals(order)).OrderStatus = OrderStatus.HANDLED;

        public void PlaceOrder(int flight, Order order) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Orders.Add(order);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
