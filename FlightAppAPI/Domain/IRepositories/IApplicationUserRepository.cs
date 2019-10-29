namespace FlightAppAPI.Domain.IRepositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetBy(string email);
        void Add(ApplicationUser user);
        void SaveChanges();
    }
}
