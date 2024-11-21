using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entites
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

        // ToString method to provide a string representation of the object
        public override string ToString()
        {
            return $"CourierCompany [CompanyName={companyName}, CouriersCount={courierDetails.Count}, EmployeesCount={employeeDetails.Count}, LocationsCount={locationDetails.Count}]";
        }
    }
}
