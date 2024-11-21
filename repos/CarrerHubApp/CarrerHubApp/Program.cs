using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Entity;
using DAO;
using Util;
using ExceptionDemo;

namespace carrerHub
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManagerImpl dbManager = new DatabaseManagerImpl();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nWelcome to CarrerHub, The Job Board!:");
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Retrieve Job Listings");
                Console.WriteLine("2. Create Applicant Profile");
                Console.WriteLine("3. Submit Job Application");
                Console.WriteLine("4. Post Job Listing");
                Console.WriteLine("5. Search Jobs by Salary Range");
                Console.WriteLine("6. Exit");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Job Listing Retrieval
                        try
                        {
                            List<JobListing> jobs = dbManager.GetJobListings();
                            if (jobs.Count == 0)
                            {
                                Console.WriteLine("No job listings found.");
                            }
                            else
                            {
                                foreach (var job in jobs)
                                {
                                    Console.WriteLine($"Job Title: {job.JobTitle}, Company ID: {job.CompanyID}, Salary: {job.Salary}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error retrieving job listings: {ex.Message}");
                        }
                        break;

                    case "2":
                        // Applicant Profile Creation
                        try
                        {
                            Console.WriteLine("Enter Applicant ID:");
                            int applicantId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter First Name:");
                            string firstName = Console.ReadLine();

                            Console.WriteLine("Enter Last Name:");
                            string lastName = Console.ReadLine();

                            Console.WriteLine("Enter Email:");
                            string email = Console.ReadLine();

                            // Validate the email format
                            EmailValidation.ValidateEmail(email);

                            Console.WriteLine("Enter Phone:");
                            string phone = Console.ReadLine();

                            // Create a new applicant object
                            Applicant newApplicant = new Applicant(applicantId, firstName, lastName, email, phone, "Resume data here");

                            // Insert applicant into the database
                            dbManager.InsertApplicant(newApplicant);

                            Console.WriteLine("Applicant profile created successfully!");
                        }
                        catch (InvalidEmailFormatException ex)
                        {
                            Console.WriteLine($"Email validation error: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error creating applicant profile: {ex.Message}");
                        }
                        break;

                    case "3":
                        // Job Application Submission
                        try
                        {
                            Console.WriteLine("Enter Job ID:");
                            int jobId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Applicant ID:");
                            int applicantId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Application ID:");
                            int applicationId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Cover Letter:");
                            string coverLetter = Console.ReadLine();

                            JobApplication application = new JobApplication(applicationId, jobId, applicantId, DateTime.Now, coverLetter);
                            dbManager.InsertJobApplication(application);
                            Console.WriteLine("Job application submitted successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error submitting job application: {ex.Message}");
                        }
                        break;

                    case "4":
                        // Company Job Posting
                        try
                        {
                            Console.WriteLine("Enter Company ID:");
                            int companyId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Job ID:");
                            int jobID = int.Parse(Console.ReadLine());

                            // Check if the JobID already exists
                            if (dbManager.CheckJobIDExists(jobID))
                            {
                                Console.WriteLine($"Job ID {jobID} already exists. Please enter a unique Job ID.");
                                break;
                            }

                            Console.WriteLine("Enter Job Title:");
                            string jobTitle = Console.ReadLine();

                            Console.WriteLine("Enter Job Description:");
                            string jobDescription = Console.ReadLine();

                            Console.WriteLine("Enter Job Location:");
                            string jobLocation = Console.ReadLine();

                            Console.WriteLine("Enter Salary:");
                            decimal salary = decimal.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Job Type(e.g., Full - Time, Part - Time):");
                            string jobType = Console.ReadLine();

                            // Create a new JobListing object
                            JobListing newJob = new JobListing(jobID, companyId, jobTitle, jobDescription, jobLocation, salary, jobType, DateTime.Now);

                            // Insert job listing into the database
                            dbManager.InsertJobListing(newJob);

                            Console.WriteLine("Job posted successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error posting job: {ex.Message}");
                        }
                        break;


                    case "5":
                        // Salary Range Query
                        try
                        {
                            Console.WriteLine("Enter Minimum Salary:");
                            decimal minSalary = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Maximum Salary:");
                            decimal maxSalary = decimal.Parse(Console.ReadLine());

                            var jobsInRange = dbManager.GetJobListings();
                            Console.WriteLine("Job Listings within Salary Range:");
                            foreach (var job in jobsInRange)
                            {
                                if (job.Salary >= minSalary && job.Salary <= maxSalary)
                                {
                                    Console.WriteLine($"Job Title: {job.JobTitle}, Salary: {job.Salary}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error retrieving jobs by salary: {ex.Message}");
                        }
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
