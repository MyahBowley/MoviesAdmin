using System.ComponentModel.DataAnnotations;

namespace MoviesAdmin.Models
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "Cannot exceed 30 characters")] // Max length 
        public string Title { get; set; } = string.Empty;
    }
}
