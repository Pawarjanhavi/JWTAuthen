using Entities;
using System;
using System.Collections.Generic;

namespace DOA
{
    public class CourierUserServiceCollectionImpl : ICourierUserService
    {
        // Variable to hold the CourierCompanyCollection
        protected CourierCompanyCollection companyObj;
        private CourierUserServiceImpl courierUserService;

        // Constructor to initialize the companyObj
        public CourierUserServiceCollectionImpl(CourierCompanyCollection companyCollection)
        {
            companyObj = companyCollection ?? throw new ArgumentNullException(nameof(companyCollection));

            // Assuming you want to create a CourierUserServiceImpl with the first company in the collection
            if (companyObj.GetAllCompanies().Count > 0)
            {
                courierUserService = new CourierUserServiceImpl(companyObj.GetAllCompanies()[0]);
            }
            else
            {
                throw new InvalidOperationException("No Courier Company available to create CourierUserServiceImpl.");
            }
        }

        // Implementation of ICourierUserService methods...

        public string PlaceOrder(Courier courierObj)
        {
            return courierUserService.PlaceOrder(courierObj);
        }

        public string GetOrderStatus(string trackingNumber)
        {
            return courierUserService.GetOrderStatus(trackingNumber);
        }

        public bool CancelOrder(string trackingNumber)
        {
            return courierUserService.CancelOrder(trackingNumber);
        }

        public List<Courier> GetAssignedOrders(string courierStaffId)
        {
            return courierUserService.GetAssignedOrders(courierStaffId);
        }
    }
}
