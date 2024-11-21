﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Entity;
using Util;

namespace DAO
{
    public class DatabaseManagerImpl : IDatabaseInitializer, IJobListing, ICompany, IApplicant, IJobApplication,
                                       JobListingRetrieval, ICompanyRetrieval, IApplicantRetrieval, IJobApplicationRetrieval
    {
        private string connectionString = null;

        public DatabaseManagerImpl()
        {
            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");


        }

        public void InitializeDatabase()
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                CREATE TABLE IF NOT EXISTS Company (
                    CompanyID INT PRIMARY KEY IDENTITY(1,1),
                    CompanyName VARCHAR(255),
                    Location VARCHAR(255)
                );

                CREATE TABLE IF NOT EXISTS JobListing (
                    JobID INT PRIMARY KEY IDENTITY(1,1),
                    CompanyID INT,
                    JobTitle VARCHAR(255),
                    JobDescription TEXT,
                    JobLocation VARCHAR(255),
                    Salary DECIMAL(10, 2),
                    JobType VARCHAR(50),
                    PostedDate DATETIME,
                    FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID)
                );

                CREATE TABLE IF NOT EXISTS Applicant (
                    ApplicantID INT PRIMARY KEY IDENTITY(1,1),
                    FirstName VARCHAR(100),
                    LastName VARCHAR(100),
                    Email VARCHAR(255) UNIQUE,
                    Phone VARCHAR(20),
                    Resume VARCHAR(255)
                );

                CREATE TABLE IF NOT EXISTS JobApplication (
                    ApplicationID INT PRIMARY KEY IDENTITY(1,1),
                    JobID INT,
                    ApplicantID INT,
                    ApplicationDate DATETIME,
                    CoverLetter TEXT,
                    FOREIGN KEY (JobID) REFERENCES JobListing(JobID),
                    FOREIGN KEY (ApplicantID) REFERENCES Applicant(ApplicantID)
                );";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Database initialized.");
        }

        // Implement IJobListing
        public void InsertJobListing(JobListing job)
        {
            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO JobListing (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                               "VALUES (@JobID, @CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JobID", job.JobID); // Include JobID
                    cmd.Parameters.AddWithValue("@CompanyID", job.CompanyID);
                    cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    cmd.Parameters.AddWithValue("@JobDescription", job.JobDescription);
                    cmd.Parameters.AddWithValue("@JobLocation", job.JobLocation);
                    cmd.Parameters.AddWithValue("@Salary", job.Salary);
                    cmd.Parameters.AddWithValue("@JobType", job.JobType);
                    cmd.Parameters.AddWithValue("@PostedDate", job.PostedDate);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Job listing inserted: {0}", job.JobTitle);
        }


        public List<JobListing> GetJobListings()
        {
            List<JobListing> jobs = new List<JobListing>();

            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                string query = "SELECT * FROM JobListing";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JobListing job = new JobListing(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetDecimal(5),
                                reader.GetString(6),
                                reader.GetDateTime(7)
                            );
                            jobs.Add(job);
                        }
                    }
                }
            }
            return jobs;
        }


        // Implement ICompany
        public void InsertCompany(Company company)
        {
            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Company (CompanyName, Location) VALUES (@CompanyName, @Location)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                    cmd.Parameters.AddWithValue("@Location", company.Location);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Company inserted: {0}", company.CompanyName);
        }

        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();

            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Company";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Company company = new Company(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            );
                            companies.Add(company);
                        }
                    }
                }
            }
            return companies;
        }

        // Implement IApplicant
        public void InsertApplicant(Applicant applicant)
        {
            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Check if the ApplicantID already exists
                string checkQuery = "SELECT COUNT(*) FROM Applicant WHERE ApplicantID = @ApplicantID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ApplicantID", applicant.ApplicantID);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Applicant ID already exists. Please enter a unique ID.");
                    }
                }

                string query = "INSERT INTO Applicant (ApplicantID, FirstName, LastName, Email, Phone, Resume) VALUES (@ApplicantID, @FirstName, @LastName, @Email, @Phone, @Resume)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicantID", applicant.ApplicantID);
                    cmd.Parameters.AddWithValue("@FirstName", applicant.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", applicant.LastName);
                    cmd.Parameters.AddWithValue("@Email", applicant.Email);
                    cmd.Parameters.AddWithValue("@Phone", applicant.Phone);
                    cmd.Parameters.AddWithValue("@Resume", applicant.Resume);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Applicant inserted: {0} {1}", applicant.FirstName, applicant.LastName);
        }



        public List<Applicant> GetApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();

            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Applicant";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Applicant applicant = new Applicant(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5)
                            );
                            applicants.Add(applicant);
                        }
                    }
                }
            }
            return applicants;
        }

        // Implement IJobApplication
        public void InsertJobApplication(JobApplication application)
        {
            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO JobApplication (JobID, ApplicantID, ApplicationDate, CoverLetter) VALUES (@JobID, @ApplicantID, @ApplicationDate, @CoverLetter)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JobID", application.JobID);
                    cmd.Parameters.AddWithValue("@ApplicantID", application.ApplicantID);
                    cmd.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
                    cmd.Parameters.AddWithValue("@CoverLetter", application.CoverLetter);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Job application submitted for Job ID: {0}", application.JobID);
        }

        public List<JobApplication> GetApplicationsForJob(int jobID)
        {
            List<JobApplication> applications = new List<JobApplication>();

            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM JobApplication WHERE JobID = @JobID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JobID", jobID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            JobApplication application = new JobApplication(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetDateTime(3),
                                reader.GetString(4)
                            );
                            applications.Add(application);
                        }
                    }
                }
            }
            return applications;
        }



        public bool CheckJobIDExists(int jobID)
        {
            connectionString = DBPropertyUtil.ReturnCn("CarrerHubCn");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM JobListing WHERE JobID = @JobID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JobID", jobID);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Returns true if JobID exists
                }
            }
        }




    }
}
