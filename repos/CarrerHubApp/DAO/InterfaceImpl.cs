using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Entity;




namespace DAO
{
    // Implementing the Apply interface
    public class JobApplicationService : Apply, GetApplicants, PostJob, GetJobs, CreateProfile, ApplyForJob
    {
        // Sample data storage
        private List<JobApplication> jobApplications = new List<JobApplication>();
        private List<JobListing> jobListings = new List<JobListing>();
        private List<Applicant> applicants = new List<Applicant>();

        // Constructor with sample data initialization
        public JobApplicationService()
        {
            // Sample job listings
            jobListings.Add(new JobListing(1, 1, "Software Engineer", "Develop and maintain software applications", "Pune", 3000, "Full-Time", DateTime.Now));
            jobListings.Add(new JobListing(2, 2, "Data Scientist", "Analyze data for business insights", "Mumbai", 5000, "Part-Time", DateTime.Now));

            // Sample applicants
            applicants.Add(new Applicant(1, "John", "Doe", "john.doe@gmail.com", "1234567890", "John's Resume"));
            applicants.Add(new Applicant(2, "Jane", "Smith", "jane.smith@gmail.com", "0987654321", "Jane's Resume"));

            // Sample job applications
            jobApplications.Add(new JobApplication(1, 1, 1, DateTime.Now, "Cover Letter for Job 1"));
            jobApplications.Add(new JobApplication(2, 2, 2, DateTime.Now, "Cover Letter for Job 2"));
        }

        public void Apply(int applicantID, int jobID, string coverLetter)
        {
            // Adding new job application to sample data
            int newApplicationID = jobApplications.Count + 1;
            jobApplications.Add(new JobApplication(newApplicationID, jobID, applicantID, DateTime.Now, coverLetter));
            Console.WriteLine("Application submitted for Applicant ID: {0} to Job ID: {1}", applicantID, jobID);
        }

        public List<Applicant> GetApplicants(int jobID)
        {
            List<Applicant> matchedApplicants = new List<Applicant>();
            foreach (var app in jobApplications)
            {
                if (app.JobID == jobID)
                {
                    Applicant applicant = applicants.Find(a => a.ApplicantID == app.ApplicantID);
                    if (applicant != null)
                    {
                        matchedApplicants.Add(applicant);
                    }
                }
            }

            return matchedApplicants;
        }

        public void PostJob(string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType, int companyID)
        {
            // Adding new job to sample data
            int newJobID = jobListings.Count + 1;
            jobListings.Add(new JobListing(newJobID, companyID, jobTitle, jobDescription, jobLocation, salary, jobType, DateTime.Now));
            Console.WriteLine("Job posted: {0}", jobTitle);
        }

        public List<JobListing> GetJobs(int companyID)
        {
            List<JobListing> matchedJobs = jobListings.FindAll(job => job.CompanyID == companyID);
            return matchedJobs;
        }

        public void CreateProfile(string email, string firstName, string lastName, string phone)
        {
            // Adding new applicant profile to sample data
            int newApplicantID = applicants.Count + 1;
            applicants.Add(new Applicant(newApplicantID, firstName, lastName, email, phone, "Sample Resume"));
            Console.WriteLine("Profile created for {0} {1}", firstName, lastName);
        }

        public void ApplyForJob(int jobID, string coverLetter)
        {
            // Assuming applicantID is always 1 for simplicity
            int applicantID = 1;

            // Adding new job application to sample data
            int newApplicationID = jobApplications.Count + 1;
            jobApplications.Add(new JobApplication(newApplicationID, jobID, applicantID, DateTime.Now, coverLetter));
            Console.WriteLine("Application submitted for Job ID: {0}", jobID);
        }
    }
}

