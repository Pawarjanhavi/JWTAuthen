using System;
using System.Collections.Generic;
using DAO;
using Entity;

internal class Program2
{
    static void Main(string[] args)
    {

        //// The following methods are called from the InterfaceImpl class, 


        JobApplicationService jobApplicationService = new JobApplicationService();

        while (true)
        {

            Console.WriteLine("\nChoose an operation:");
            Console.WriteLine("\n1. Create Profile");
            Console.WriteLine("2. Post Job");
            Console.WriteLine("3. Apply for Job");
            Console.WriteLine("4. Get Applicants");
            Console.WriteLine("5. Get Jobs");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Create Profile
                    Console.WriteLine("Enter Email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter First Name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter Phone:");
                    string phone = Console.ReadLine();
                    jobApplicationService.CreateProfile(email, firstName, lastName, phone);
                    break;

                case "2":
                    // Post Job
                    Console.WriteLine("Enter Job Title:");
                    string jobTitle = Console.ReadLine();
                    Console.WriteLine("Enter Job Description:");
                    string jobDescription = Console.ReadLine();
                    Console.WriteLine("Enter Job Location:");
                    string jobLocation = Console.ReadLine();
                    Console.WriteLine("Enter Salary:");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter Job Type (e.g., Full-Time, Part-Time):");
                    string jobType = Console.ReadLine();
                    Console.WriteLine("Enter Company ID:");
                    int companyID = Convert.ToInt32(Console.ReadLine());
                    jobApplicationService.PostJob(jobTitle, jobDescription, jobLocation, salary, jobType, companyID);
                    break;

                case "3":
                    // Apply for Job
                    Console.WriteLine("Enter Job ID:");
                    int jobID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Cover Letter:");
                    string coverLetter = Console.ReadLine();
                    Console.WriteLine("Enter Applicant ID:");
                    int applicantID = Convert.ToInt32(Console.ReadLine()); // Assuming you have the applicant's ID
                    jobApplicationService.Apply(applicantID, jobID, coverLetter);
                    break;

                case "4":
                    // Get Applicants
                    Console.WriteLine("Enter Job ID to get applicants:");
                    int getJobID = Convert.ToInt32(Console.ReadLine());
                    List<Applicant> applicants = jobApplicationService.GetApplicants(getJobID);
                    Console.WriteLine("Applicants for Job ID {0}:", getJobID);
                    foreach (var applicant in applicants)
                    {
                        Console.WriteLine("{0} {1} (ID: {2})", applicant.FirstName, applicant.LastName, applicant.ApplicantID);
                    }
                    break;

                case "5":
                    // Get Jobs
                    Console.WriteLine("Enter Company ID to get jobs:");
                    int getCompanyID = Convert.ToInt32(Console.ReadLine());
                    List<JobListing> jobs = jobApplicationService.GetJobs(getCompanyID);
                    Console.WriteLine("Jobs for Company ID {0}:", getCompanyID);
                    foreach (var job in jobs)
                    {
                        Console.WriteLine("Job ID: {0}, Title: {1}, Location: {2}", job.JobID, job.JobTitle, job.JobLocation);
                    }
                    break;

                case "6":
                    // Exit
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}