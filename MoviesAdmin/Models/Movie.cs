namespace MoviesAdmin.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Synopsis { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string ContentRating { get; set; } = string.Empty; // e.g. PG, PG-13, R

        public DateTime ReleaseDate { get; set; }

        public int Runtime { get; set; } // minutes

        public string OriginalLanguage { get; set; } = string.Empty;

        // IDEAS:
        // public int BoxOffice { get; set; } // Gross earnings 
        // videos
        // photos
        // cast & crew (list?)
            // Director
            // producer
            // screenwriter
            // distributor
            // Production Co

    }
}
