using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlightAppAPI.Data.Repositories
{
    public class EntertainmentRepository : IEntertainmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Movie> _movies;
        private readonly DbSet<Music> _music;

        public EntertainmentRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _movies = dbContext.Movies;
            _music = dbContext.Music;
        }

        public IList<Movie> GetMovies()
        {
            return _movies.ToList();
        }

        public IList<Music> GetMusic()
        {
            return _music.ToList();
        }
    }
}
