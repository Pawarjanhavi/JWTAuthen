using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Payment
    {
        private long paymentID;
        private long courierID;
        private double amount;
        private DateTime paymentDate;

        // Default constructor
        public Payment() { }

        // Parameterized constructor
        public Payment(long paymentID, long courierID, double amount, DateTime paymentDate)
        {
            this.paymentID = paymentID;
            this.courierID = courierID;
            this.amount = amount;
            this.paymentDate = paymentDate;
        }

        // Getters and setters using full syntax
        public long PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }

        public long CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        // ToString method to provide a string representation of the object
        public override string ToString()
        {
            return $"Payment [PaymentID={paymentID}, CourierID={courierID}, Amount={amount}, PaymentDate={paymentDate}]";
        }
    }
}
