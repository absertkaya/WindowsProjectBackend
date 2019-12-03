namespace FlightAppAPI.Domain
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Poster { get; set; }

        public Music(string title, string artist, string poster)
        {
            Title = title;
            Artist = artist;
            Poster = poster;
        }
    }
}
