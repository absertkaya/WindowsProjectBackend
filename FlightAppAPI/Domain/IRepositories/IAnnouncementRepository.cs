using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
