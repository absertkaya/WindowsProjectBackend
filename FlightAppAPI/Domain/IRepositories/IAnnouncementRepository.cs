using System.Collections.Generic;

namespace FlightAppAPI.Domain.IRepositories
{
    public interface IAnnouncementRepository
    {
        void Add(Announcement announcement);
        void Delete(Announcement announcement);
        void Update(Announcement announcement);
        IList<Announcement> GetAllAnnouncements();
        Announcement GetById(int id);
        void SaveChanges(Announcement announcement);
    }
}
