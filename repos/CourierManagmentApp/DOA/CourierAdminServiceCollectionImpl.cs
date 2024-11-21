using Entities; // Assuming you have this namespace for your entities
using System.Collections.Generic;

namespace DOA
{
    public class CourierAdminServiceCollectionImpl : CourierUserServiceCollectionImpl, ICourierAdminService
    {
        private readonly CourierAdminServiceImpl _courierAdminServiceImpl;

        // Constructor that accepts a CourierCompanyCollection
        public CourierAdminServiceCollectionImpl(CourierCompanyCollection companyCollection)
            : base(companyCollection)
        {
            _courierAdminServiceImpl = new CourierAdminServiceImpl(companyCollection);
        }

        // Method to add a courier
        public void AddCourier(Courier courier)
        {
            _courierAdminServiceImpl.AddCourier(courier);
        }

        // Method to remove a courier by tracking number
        public void RemoveCourier(string trackingNumber)
        {
            _courierAdminServiceImpl.RemoveCourier(trackingNumber);
        }

        // Method to get all couriers
        public List<Courier> GetAllCouriers()
        {
            return _courierAdminServiceImpl.GetAllCouriers();
        }

        // Method to get all employees
        public List<Employee> GetAllEmployees()
        {
            return _courierAdminServiceImpl.GetAllEmployees();
        }

        // Method to add an employee
        public void AddEmployee(Employee employee)
        {
            _courierAdminServiceImpl.AddEmployee(employee);
        }

        // Method to add courier staff
      
}
