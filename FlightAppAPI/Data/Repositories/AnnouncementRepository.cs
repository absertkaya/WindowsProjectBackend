using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {

        private ApplicationDbContext _ctx;

        public AnnouncementRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Announcement announcement)
        {
            _ctx.Announcements.Add(announcement);
        }

        public void Delete(Announcement announcement)
        {
            _ctx.Announcements.Remove(announcement);
        }

        public IList<Announcement> GetAllAnnouncements()
        {
            return _ctx.Announcements.ToList();
        }

        public Announcement GetById(int id)
        {
            return _ctx.Announcements.Find(id);
        }

        public void SaveChanges(Announcement announcement)
        {
            _ctx.SaveChanges();
        }

        public void Update(Announcement announcement)
        {
            _ctx.Announcements.Update(announcement);
        }
    }
}
