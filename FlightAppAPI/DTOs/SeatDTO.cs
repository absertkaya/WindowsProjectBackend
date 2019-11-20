using FlightAppAPI.Domain;

namespace FlightAppAPI.DTOs
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public ClassType ClassType { get; set; }
        public PassengerMinimal Passenger {get; set;}

        public class PassengerMinimal
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public static SeatDTO FromSeat(Seat seat)
        {
            return new SeatDTO {
                Id = seat.Id,
                Nr = seat.Nr,
                ClassType = seat.ClassType,
                Passenger = (seat.Passenger is null? null : 
                    new PassengerMinimal { Id = seat.Passenger.Id, FirstName = seat.Passenger.FirstName, LastName = seat.Passenger.LastName })
            };
        }
    }

}
