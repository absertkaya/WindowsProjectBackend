﻿using FlightAppAPI.Domain;
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
        
        public IList<Announcement> GetAnnouncementsBy(int flight, ApplicationUser passenger) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Announcements.Where(a => a.Receiver == null || a.Receiver == passenger).OrderByDescending(a => a.Timestamp).ToList();

        public IList<Announcement> GetPersonalAnnouncementsBy(int flight, Passenger passenger) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Announcements.Where(a => a.Receiver == passenger).ToList();

        public Flight GetFlightBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight));

        public Flight GetFlightDetailBy(int flight) => _context.Flights.FirstOrDefault(f => f.Id == flight);

        public IList<Seat> GetSeatsBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Seats.OrderBy(s => s.Nr).ToList();

        public IList<Staff> GetStaffBy(int flight) => Flights.FirstOrDefault(f => f.Id.Equals(flight)).Staff;

        public void MovePassenger(int seat1, int seat2)
        {
            Seat _seat1 = _context.Seats.Include(s => s.Passenger).FirstOrDefault(s => s.Id.Equals(seat1));
            Seat _seat2 = _context.Seats.Include(s => s.Passenger).FirstOrDefault(s => s.Id.Equals(seat2));
            Passenger pas1 = _seat1.Passenger;
            Passenger pas2 = _seat2.Passenger;

            _seat1.Passenger = pas2;
            if (pas2 != null)
            {
                pas2.Seat = _seat1;
                pas2.SeatId = _seat1.Id;
            }
            
            _context.SaveChanges();
            _seat2.Passenger = pas1;
            if (pas1 != null)
            {
                pas1.Seat = _seat2;
                pas1.SeatId = _seat2.Id;
            }
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IList<Passenger> GetPassengersBy(int flight)
        {
            return Flights.FirstOrDefault(f => f.Id.Equals(flight)).Seats.Where(s => s.Passenger != null).Select(s => s.Passenger).ToList();
        }

        public IList<Passenger> GetFriends(int flightId, int passengerId)
        {
            var frens = _context.Friends
                .Where(f => f.PassengerId == passengerId || f.Passenger2Id == passengerId)
                .Include(f => f.Passenger)
                .ThenInclude(p => p.Seat)
                .Include(f => f.Passenger2)
                .ThenInclude(p => p.Seat);

            var f1 = frens.Where(f => f.Passenger.Id != passengerId && f.Passenger2.Id == passengerId).Select(f => f.Passenger).ToList();
            var f2 = frens.Where(f => f.Passenger.Id == passengerId && f.Passenger2.Id != passengerId).Select(f => f.Passenger2);
            f1.AddRange(f2);

            return f1.Distinct().ToList();
                
        }

        public IList<Message> GetMessages(int id, int friendId)
        {
            return _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => m.Sender.Id == id && m.Receiver.Id == friendId || m.Sender.Id == friendId && m.Receiver.Id == id)
                .OrderByDescending(m => m.Timestamp)
                .ToList();
        }
    }
}
