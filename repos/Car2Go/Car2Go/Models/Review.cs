using ModelBindingDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace Car2Go.Models
{
    public class Review
    {
        [Required(ErrorMessage = "Review ID is required.")]
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Review Text is required.")]
        public string ReviewText { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Review Created data is required.")]
        public DateOnly ReviewCreatedAt { get; set; }

        //public int CarId {  get; set; }
        //public int UserId {  get; set; }

        //navigation properties
        public User user { get; set; }
    }
}
