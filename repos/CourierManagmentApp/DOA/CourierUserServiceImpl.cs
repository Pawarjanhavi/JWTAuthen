using Entities;
using System.Collections.Generic;

namespace DOA
{
    public class CourierUserServiceImpl : ICourierUserService
    {
        protected CourierCompany companyObj; // Ensure this is initialized somewhere, either in the constructor or elsewhere

        // Constructor for CourierUserServiceImpl (You may want to initialize companyObj here)
        public CourierUserServiceImpl(CourierCompany company)
        {
            companyObj = company;
        }

        public string PlaceOrder(Courier courierObj)
        {
            // Generate a unique tracking number and set it on the courierObj
            courierObj.TrackingNumber = Courier.GenerateTrackingNumber(); // Ensure this method is implemented
            companyObj.AddCourier(courierObj); // Add to company records
            return courierObj.TrackingNumber; // Return tracking number
        }

        public string GetOrderStatus(string trackingNumber)
        {
            var courier = companyObj.GetCourierByTrackingNumber(trackingNumber); // Fetch courier by tracking number
            return courier != null ? courier.Status.ToString() : "Invalid tracking number"; // Convert Status to string
        }

        public bool CancelOrder(string trackingNumber)
        {
            var courier = companyObj.GetCourierByTrackingNumber(trackingNumber); // Fetch courier by tracking number
            if (courier != null)
            {
                // Set status to cancelled
                courier.Status = CourierStatus.Cancelled; // Ensure CourierStatus.Cancelled is defined correctly
                // Optionally: Save the updated courier in company records
                return true; // Successful cancellation
            }
            return false; // Order not found
        }

        public List<Courier> GetAssignedOrders(string courierStaffId)
        {
            int staffId;
            if (int.TryParse(courierStaffId, out staffId))
            {
                return companyObj.GetAssignedCouriers(staffId); // Call with int
            }
            else
            {
                throw new ArgumentException("Courier staff ID must be a valid integer.", nameof(courierStaffId));
            }
        }
    }
}
