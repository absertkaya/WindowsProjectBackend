﻿using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class PassengerFlightConfiguration : IEntityTypeConfiguration<PassengerFlight>
    {
        public void Configure(EntityTypeBuilder<PassengerFlight> builder)
        {
            builder.ToTable("PassengerFlight");

            builder.HasKey(p => p.PassengerFlightId);

            builder.HasOne(p => p.Passenger).WithMany(s => s.PassengerFlights).HasForeignKey(s => s.PassengerId);
            builder.HasOne(p => p.Flight).WithMany(f => f.PassengerFlights).HasForeignKey(f => f.FlightId);
            builder.HasOne(p => p.Seat).WithOne().HasForeignKey<Seat>(s => s.SeatId);
            builder.HasMany(p => p.SentMessages).WithOne(m => m.Sender).IsRequired();
            builder.HasMany(p => p.ReceivedMessages).WithOne(m => m.Receiver).IsRequired();
            builder.HasMany(p => p.PlacedOrders).WithOne().IsRequired();
        }
    }
}
