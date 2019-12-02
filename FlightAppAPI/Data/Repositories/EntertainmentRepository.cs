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

        public EntertainmentRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _movies = dbContext.Movies;
        }

        public IList<Movie> GetMovies()
        {
            return _movies.ToList();
        }
    }
}
