namespace FlightAppAPI.Domain.IRepositories
{
    public interface IApplicationUserRepository
    {
        Staff GetStaffBy(string email);
        Passenger GetPassengerBy(string email);
        void AddStaff(Staff user);
        void AddPassenger(Passenger user);
        void SaveChanges();
    }
}
