using MoviesAdmin.Models.Enums;
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
            Description = "Please enter the movie synopsis", 
            Prompt = "Enter movie synopsis")]
        public string Synopsis { get; set; } = string.Empty;


        [Required]
        [Display(
            Name = "Genre", 
            Description = "Please choose the genre", 
            Prompt = "Choose genre")]
        public Genre Genre { get; set; }


        [Required]
        [Display(
            Name = "Content Rating", 
            Description = "Please choose the content rating", 
            Prompt = "Choose content rating")]
        public ContentRating ContentRating { get; set; } // e.g. PG, PG-13, R


        [Required]
        //[Range(typeof(DateOnly), "1800-01-01", "9999-12-31",
        //    ErrorMessage = "The theatrical release date cannot be earlier than January 1st, 1800")]
        [Display(
            Name = "Theatrical Release",
            Description = "Please enter the date of the movie's theatrical release",
            Prompt = "YYYY-MM-DD")]
        public DateOnly ReleaseDate { get; set; }


        [Required]
        [Range(1, 576000)] // Max is 40 days
        [Display(
            Name = "Run Time (min)", 
            Description = "Please enter the movie's runtime in minutes", 
            Prompt = "120")]
        public int Runtime { get; set; } // Minutes


        [Required]
        [Display(
            Name = "Original Language", 
            Description = "Please enter the movie's original released language", 
            Prompt = "English")]
        public Language OriginalLanguage { get; set; }


        // IDEAS:
        //public int BoxOffice { get; set; } // Gross Earnings
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
