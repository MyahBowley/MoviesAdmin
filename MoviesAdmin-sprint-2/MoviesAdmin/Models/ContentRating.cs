using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MoviesAdmin.Models
{
    public class ContentRating
    {
        // "Primary Key"
        [Required]
        public int Id { get; set; }

        // Navigation Property
        [ValidateNever]
        public List<Movie> Movies { get; set; } = new List<Movie>();

        [Required]
        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")] // Max length 
        public string Title { get; set; } = string.Empty;
    }
}

//namespace MoviesAdmin.Models
//{
//    public enum ContentRating
//    {
//        G,
//        PG,
//        PG13,
//        R,
//        NC17,
//        NotRated,
//        UnRated
//    }
//}
