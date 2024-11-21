using System.ComponentModel.DataAnnotations;

namespace Car2Go.Models
{
    public class Location
    {
        [Required(ErrorMessage = "LocationId is required")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Name of Location is required")]
        public string LocationName { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        public string ZipCode { get; set; }

        //navigation properties
        public ICollection<Car> Car { get; set; }
    }
}
