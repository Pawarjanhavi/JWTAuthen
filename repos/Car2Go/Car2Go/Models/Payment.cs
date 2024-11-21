using System.ComponentModel.DataAnnotations;

namespace Car2Go.Models
{
    public class Payment
    {
        [Required(ErrorMessage = "PaymentId is required")]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "PaymentDate is required")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "Payment Amount is required")]
        public decimal PaymentAmount { get; set; }

        [Required(ErrorMessage = "Payment Status is required")]
        public string PaymentStatus { get; set; }

        //public int ReservationId {  get; set; }

        //navigation properties
        public Reservation reservation { get; set; }


    }

    /*public enum PaymentStatus
    {
        Successful,
        Failed,
        Pending
    }*/
}
