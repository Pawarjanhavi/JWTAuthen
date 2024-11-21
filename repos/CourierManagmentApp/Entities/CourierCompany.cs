using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class CourierCompany
    {
        private string companyName;
        private List<Courier> courierDetails;
        private List<Employee> employeeDetails;
        private List<Location> locationDetails;

        // Default constructor
        public CourierCompany()
        {
            courierDetails = new List<Courier>();
            employeeDetails = new List<Employee>();
            locationDetails = new List<Location>();
        }

        // Parameterized constructor
        public CourierCompany(string companyName)
        {
            this.companyName = companyName;
            courierDetails = new List<Courier>();
            employeeDetails = new List<Employee>();
            locationDetails = new List<Location>();
        }

        // Getters and setters using full syntax
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public List<Courier> CourierDetails
        {
            get { return courierDetails; }
            set { courierDetails = value; }
        }

        public List<Employee> EmployeeDetails
        {
            get { return employeeDetails; }
            set { employeeDetails = value; }
        }

        public List<Location> LocationDetails
        {
            get { return locationDetails; }
            set { locationDetails = value; }
        }

        // Method to add a new courier
        public void AddCourier(Courier courier)
        {
            courierDetails.Add(courier);
        }

        // Method to add a new employee (staff)
        public int AddStaff(Employee employee)
        {
            if (employee != null)
            {
                // Here, you might want to assign an ID to the employee or handle it differently
                employeeDetails.Add(employee); // Add the employee to the list
                return employeeDetails.Count; // Return the new count as a dummy ID
            }
            return -1; // Return -1 or handle the error as needed
        }

        // Method to get a courier by tracking number
        public Courier GetCourierByTrackingNumber(string trackingNumber)
        {
            return courierDetails.FirstOrDefault(c => c.TrackingNumber == trackingNumber);
        }

        // Method to get assigned couriers for a specific courier staff member
        public List<Courier> GetAssignedCouriers(int courierStaffId)
        {
            return courierDetails.Where(c => c.CourierStaffId == courierStaffId).ToList();
        }

        // ToString method to provide a string representation of the object
        public override string ToString()
        {
            return $"CourierCompany [CompanyName={companyName}, CouriersCount={courierDetails.Count}, EmployeesCount={employeeDetails.Count}, LocationsCount={locationDetails.Count}]";
        }
    }
}
