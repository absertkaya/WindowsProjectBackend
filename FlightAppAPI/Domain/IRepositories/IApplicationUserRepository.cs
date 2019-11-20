namespace FlightAppAPI.Domain.IRepositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUserBy(string email);
        ApplicationUser GetUserById(int id);
        void AddUser(ApplicationUser user);
    }
}
