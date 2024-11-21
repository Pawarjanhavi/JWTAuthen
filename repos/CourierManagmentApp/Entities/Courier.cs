using System;

namespace Entities
{
    public enum CourierStatus
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled,
        Returned
    }

    public class Courier
    {
        private int courierID;
        private string senderName;
        private string senderAddress;
        private string receiverName;
        private string receiverAddress;
        private double weight;
        private string status; // Stored as string for backward compatibility
        private string trackingNumber;
        private DateTime? deliveryDate; // Nullable for cases where delivery is not yet set
        private int userID;

        // Default constructor
        public Courier() { }

        // Parameterized constructor
        public Courier(int courierID, string senderName, string senderAddress, string receiverName, string receiverAddress,
            double weight, CourierStatus status, string trackingNumber, DateTime? deliveryDate, int userID)
        {
            this.courierID = courierID;
            this.senderName = senderName;
            this.senderAddress = senderAddress;
            this.receiverName = receiverName;
            this.receiverAddress = receiverAddress;
            this.Weight = weight;
            this.Status = status; // Using enum
            this.trackingNumber = trackingNumber;
            this.deliveryDate = deliveryDate;
            this.userID = userID;
        }

        public int CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        public string SenderAddress
        {
            get { return senderAddress; }
            set { senderAddress = value; }
        }

        public string ReceiverName
        {
            get { return receiverName; }
            set { receiverName = value; }
        }

        public string ReceiverAddress
        {
            get { return receiverAddress; }
            set { receiverAddress = value; }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value <= 0) throw new ArgumentException("Weight must be greater than zero.");
                weight = value;
            }
        }

        public CourierStatus Status
        {
            get { return (CourierStatus)Enum.Parse(typeof(CourierStatus), status); }
            set { status = value.ToString(); }
        }

        public string TrackingNumber
        {
            get { return trackingNumber; }
            set { trackingNumber = value; }
        }

        public DateTime? DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int CourierStaffId
        {
            get { return CourierStaffId; }
            set { CourierStaffId = value; }
        }

        public static string GenerateTrackingNumber()
        {
            return Guid.NewGuid().ToString(); // Generates a unique identifier
        }

        // ToString method
        public override string ToString()
        {
            return $"Courier [CourierID={courierID}, SenderName={senderName}, ReceiverName={receiverName}, " +
                   $"Status={Status}, TrackingNumber={trackingNumber}, DeliveryDate={deliveryDate?.ToString("yyyy-MM-dd")}]";
        }
    }
}
