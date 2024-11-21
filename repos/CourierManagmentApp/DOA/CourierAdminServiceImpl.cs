using Entities; // Assuming Entities contains the Courier and Employee classes
using System;
using System.Collections.Generic;

namespace DOA
{
    public class CourierAdminServiceImpl : ICourierAdminService
    {
        private readonly CourierCompanyCollection _companyCollection;

        // Constructor to initialize the CourierCompanyCollection
        public CourierAdminServiceImpl(CourierCompanyCollection companyCollection)
        {
            _companyCollection = companyCollection ?? throw new ArgumentNullException(nameof(companyCollection));
        }

        // Method to add a courier
        public void AddCourier(Courier courier)
        {
            if (courier == null) throw new ArgumentNullException(nameof(courier));
            var company = _companyCollection.GetAllCompanies()[0]; // Assuming at least one company exists
            company.AddCourier(courier);
        }

        // Method to remove a courier by tracking number
        public void RemoveCourier(string trackingNumber)
        {
            var company = _companyCollection.GetAllCompanies()[0]; // Assuming at least one company exists
            var courier = company.GetCourierByTrackingNumber(trackingNumber);
            if (courier != null)
            {
                company.CourierDetails.Remove(courier);
            }
            else
            {
                throw new KeyNotFoundException("Courier not found.");
            }
        }

        // Method to get all couriers
        public List<Courier> GetAllCouriers()
        {
            return _companyCollection.GetAllCompanies()[0].CourierDetails; // Assuming at least one company exists
        }

        // Method to get all employees
        public List<Employee> GetAllEmployees()
        {
            return _companyCollection.GetAllCompanies()[0].EmployeeDetails; // Assuming at least one company exists
        }

        // Method to add an employee
        public void AddEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            var company = _companyCollection.GetAllCompanies()[0]; // Assuming at least one company exists
            company.EmployeeDetails.Add(employee);
        }

        // Method to add courier staff
        
    }
}
