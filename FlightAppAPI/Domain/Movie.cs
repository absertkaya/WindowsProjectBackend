using System;

namespace FlightAppAPI.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }

        public Movie(string title, DateTime releaseDate, int runtime, string description, string director, string poster, string trailer)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Runtime = runtime;
            Description = description;
            Director = director;
            Poster = poster;
            Trailer = trailer;
        }
    }
}
