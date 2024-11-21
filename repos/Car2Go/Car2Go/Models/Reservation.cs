using System.ComponentModel.DataAnnotations;
using ModelBindingDemo.Models;

namespace Car2Go.Models
{
    public class Reservation
    {
        [Required(ErrorMessage = "Reservation ID is required")]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Reservation Status is required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Pick-Up date is required")]
        public DateTime PickUpDate { get; set; }

        [Required(ErrorMessage = "Drop-Off date is required")]
        public DateTime DropOffDate { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        //public int UserId {  get; set; }
        //public int CarId {  get; set; }

        //navigation properties
        public User user { get; set; }
        public Car car { get; set; }
        public ICollection<Payment> payments { get; set; }
    }
}
