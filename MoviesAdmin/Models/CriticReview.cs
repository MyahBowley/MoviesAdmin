using System.ComponentModel.DataAnnotations;

namespace MoviesAdmin.Models
{
    public class CriticReview
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(500, ErrorMessage = "Cannot exceed 500 characters")] // Max length 
        public string Description { get; set; } = string.Empty;


        [Required]
        [Range(0, 5)] // allows 0 - 5 star ratings
        public int StarRating { get; set; };


        [Required]
        public Boolean IsPublished { get; set; } // I'm assuming this allows the user to make a draft and not post it?


        [Required]
        public int CreatedBy { get; set; } // The user who created this (int because we will use the user ID)


        [Required]
        public int CreatedDate { get; set; } // Cate the review was created
    }
}
