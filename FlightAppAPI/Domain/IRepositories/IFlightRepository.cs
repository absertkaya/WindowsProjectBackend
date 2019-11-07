﻿using System.Collections.Generic;

namespace FlightAppAPI.Domain.IRepositories
{
    public interface IFlightRepository
    {
        IList<Announcement> GetAnnouncementsBy(int flight);
        void CreateAnnouncement(int flight, Announcement announcement);

        IList<Staff> GetStaffBy(int flight);

        IList<Seat> GetSeatsBy(int flight);
        void MovePassenger(int seat1, int seat2);

        void PlaceOrder(int flight, Order order);
        IList<Order> GetOrdersBy(int flight);
        void HandleOrder(int order);

        IList<Product> GetProducts();

        Flight GetFlightBy(int flight);
        void SaveChanges();
    }
}