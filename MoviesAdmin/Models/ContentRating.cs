using System.ComponentModel.DataAnnotations;

namespace MoviesAdmin.Models
{
    public class ContentRating
    {
        [Required]
        public int Id { get; set; }


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
