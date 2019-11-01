namespace FlightAppAPI.Domain.IRepositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUserBy(string email);
        void AddUser(ApplicationUser user);
    }
}
