using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlightAppAPI.Data.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        #region Init
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Flight> _flights;

        public FlightRepository(ApplicationDbContext dbContext)
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
        public void CreateAnnouncement(int flight, Announcement announcement) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Announcements.Add(announcement);


        public IList<Announcement> GetAnnouncementsBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Announcements.Where(a => a.Receiver == null).ToList();

        public IList<Announcement> GetPersonalAnnouncementsBy(int flight, Passenger passenger) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Announcements.Where(a => a.Receiver == passenger).ToList();

        public Flight GetFlightBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight));

        public IList<Order> GetOrdersBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Orders;

        public IList<Product> GetProducts() => _context.Products.ToList();

        public IList<Seat> GetSeatsBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Seats;

        public IList<Staff> GetStaffBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Staff;

        public void HandleOrder(int order) => _context.Orders.FirstOrDefault(o => o.Id.Equals(order)).OrderStatus = OrderStatus.HANDLED;

        public void MovePassenger(int seat1, int seat2)
        {
            Seat _seat1 = _context.Seats.Include(s => s.Passenger).FirstOrDefault(s => s.Id.Equals(seat1));
            Seat _seat2 = _context.Seats.Include(s => s.Passenger).FirstOrDefault(s => s.Id.Equals(seat2));
            Passenger placeholder = _seat1.Passenger;
            _seat1.Passenger = _seat2.Passenger;
            _seat2.Passenger = placeholder;
        }

        public void PlaceOrder(int flight, Order order) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Orders.Add(order);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IList<Passenger> GetPassengersBy(int flight)
        {
            return Flights.FirstOrDefault(f => f.Id.Equals(flight)).Seats.Where(s => s.Passenger != null).Select(s => s.Passenger).ToList();
        }
    }
}
