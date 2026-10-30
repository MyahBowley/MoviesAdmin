using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MoviesAdmin.Models
{
    public class Genre
    {
        // "Primary Key"
        [Required]
        public int Id { get; set; }

        // Navigation Property
        [ValidateNever]
        public List<Movie> Movies { get; set; } = new List<Movie>();

        [Required]
        [StringLength(30, ErrorMessage = "Cannot exceed 30 characters")] // Max length 
        public string Title { get; set; } = string.Empty;
    }
}

//namespace MoviesAdmin.Models
//{
//    public enum Genre
//    {
//        Action,
//        Adventure,
//        Animation,
//        Anime,
//        Biography,
//        Comedy,
//        Crime,
//        Documentary,
//        Drama,
//        Entertainment,
//        Family,
//        Fantasy,
//        Health,
//        History,
//        Holiday,
//        Horror,
//        Music,
//        Musical,
//        Mystery,
//        Nature,
//        News,
//        Reality,
//        Romance,
//        //[Display(Name="Sci-Fi")]
//        SciFi,
//        Short,
//        Soap,
//        Sports,
//        Thriller,
//        Travel,
//        Variety,
//        War,
//        Western 
//    }
//}
