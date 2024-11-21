using System;
using System.Collections.Generic;
using System.Linq;
using Entites;
 // Ensure this namespace matches the correct one for your Entities classes

namespace DOA
{
    public class CourierServiceProvider : ICourierUserService, ICourierAdminService
    {
        private List<Courier> orders = new List<Courier>();
        private List<Employee> employees = new List<Employee>();

        public string PlaceOrder(Courier courier)
        {
            // Add the courier order to the list
            orders.Add(courier);
            return courier.TrackingNumber; // Return the tracking number
        }

        public string GetOrderStatus(string trackingNumber)
        {
            // Find the order by tracking number
            var order = orders.FirstOrDefault(o => o.TrackingNumber == trackingNumber);
            return order?.Status ?? "Order not found."; // Return status or not found message
        }

        public bool CancelOrder(string trackingNumber)
        {
            // Find the order by tracking number
            var order = orders.FirstOrDefault(o => o.TrackingNumber == trackingNumber);
            if (order != null)
            {
                orders.Remove(order); // Remove the order if found
                return true; // Return true indicating success
            }
            return false; // Return false if order not found
        }

        public List<Courier> GetAssignedOrders(int courierStaffId)
        {
            // Get orders assigned to the specified courier staff
            return orders.Where(o => o.CourierStaffId == courierStaffId).ToList();
        }

        public int AddCourierStaff(Employee employee)
        {
            // Add the employee to the list
            employees.Add(employee);
            return employee.EmployeeID; // Return the ID of the newly added employee
        }
    }
}
