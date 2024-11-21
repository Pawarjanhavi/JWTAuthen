using System;
using System.Collections.Generic;

namespace Entities
{
    public class CourierCompanyCollection
    {
        // List to hold the courier companies
        private List<CourierCompany> companies;

        // Constructor to initialize the companies list
        public CourierCompanyCollection()
        {
            companies = new List<CourierCompany>();
        }

        // Method to add a new company to the collection
        public void AddCompany(CourierCompany company)
        {
            if (company != null && !companies.Contains(company))
            {
                companies.Add(company);
            }
            else
            {
                throw new ArgumentException("Company cannot be null or already exists in the collection.");
            }
        }

        // Method to remove a company from the collection
        public void RemoveCompany(CourierCompany company)
        {
            if (company != null && companies.Contains(company))
            {
                companies.Remove(company);
            }
            else
            {
                throw new ArgumentException("Company cannot be null and must exist in the collection to remove.");
            }
        }

        // Method to get all companies in the collection
        public List<CourierCompany> GetAllCompanies()
        {
            return new List<CourierCompany>(companies); // Return a copy to prevent modification
        }

        // Method to find a company by its name
        public CourierCompany FindCompanyByName(string name)
        {
            return companies.FirstOrDefault(c => c.CompanyName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Method to count the number of companies in the collection
        public int Count()
        {
            return companies.Count;
        }
    }
}
