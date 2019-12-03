using System.Collections.Generic;

namespace FlightAppAPI.Domain.IRepositories
{
    public interface IEntertainmentRepository
    {
        IList<Movie> GetMovies();
        IList<Music> GetMusic();
    }
}
