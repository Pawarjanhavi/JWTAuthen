using System.ComponentModel.DataAnnotations;

namespace Car2Go.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        [Required]
        public decimal PricePerDay { get; set; }
        [Required]
        public string Description { get; set; }
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        public bool Available { get; set; }

        //public int LocationId {  get; set; }

        //navigation properties
        public ICollection<Reservation> reservations { get; set; }
        public ICollection<Review> reviews { get; set; }
        public Location location { get; set; }
    }
}
