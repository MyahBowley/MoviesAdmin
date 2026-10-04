using System.ComponentModel.DataAnnotations;

namespace MoviesAdmin.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(100)] // Max length
        [Display(
            Name = "Title", 
            Description = "Please enter the movie title", 
            Prompt = "Enter movie title")]
        public string Title { get; set; } = string.Empty;


        [Required]
        [StringLength(500)] // Keep Synopsis short
        [Display(
            Name = "Synopsis", 
            Description = "Please enter the movie's synopsis", 
            Prompt = "")]
        public string Synopsis { get; set; } = string.Empty;


        [Required]
        [Display(
            Name = "Genre", 
            Description = "Please choose the genre", 
            Prompt = "Action")]
        public string Genre { get; set; } = string.Empty;


        [Required]
        [Display(
            Name = "Content Rating", 
            Description = "Please choose the content rating", 
            Prompt = "PG-13")]
        public string ContentRating { get; set; } = string.Empty; // e.g. PG, PG-13, R


        [Required]
        [Range(typeof(DateOnly), "01-01-1800", "12-31-9999",
            ErrorMessage = "The theatrical release date cannot be earlier than January 1st, 1800")]
        [Display(
            Name = "Theatrical Release Date",
            Description = "Please enter the date of the movie's theatrical release",
            Prompt = "01-01-2000")]
        public DateOnly ReleaseDate { get; set; }


        [Required]
        [Range(1, 576000)] // Max is 40 days
        [Display(
            Name = "Run Time", 
            Description = "Please enter the movie's runtime in minutes", 
            Prompt = "120")]
        public int Runtime { get; set; } // Minutes


        [Required]
        [Display(
            Name = "Original Language", 
            Description = "Please enter the movie's original released language", 
            Prompt = "English")]
        public string OriginalLanguage { get; set; } = string.Empty;

         public int BoxOffice { get; set; } // Gross Earnings

        // IDEAS:
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
