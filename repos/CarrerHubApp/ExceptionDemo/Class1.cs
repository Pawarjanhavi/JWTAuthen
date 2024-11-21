using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Util;


namespace ExceptionDemo
{
    // Invalid Email Format Exception
    public class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException(string message) : base(message) { }
    }

    public static class EmailValidation
    {
        public static void ValidateEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                throw new InvalidEmailFormatException("Invalid email format. Please enter a valid email address.");
            }
        }
    }

    // Salary Calculation Exception
    public class SalaryCalculation
    {
        public static double CalculateAverageSalary(List<double> salaries)
        {
            double total = 0;
            int count = 0;

            foreach (var salary in salaries)
            {
                if (salary < 0)
                {
                    throw new ArgumentException($"Invalid salary value: {salary}. Salary must be non-negative.");
                }
                total += salary;
                count++;
            }

            return total / count;
        }
    }

    // File Upload Exception Handling
    public class FileUploadHandler
    {
        public static void UploadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found. Please check the file path.");
            }

            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length > 1048576) // Limit file size to 1 MB
            {
                throw new Exception("File size exceeds the allowed limit of 1 MB.");
            }

            string[] allowedExtensions = { ".pdf", ".docx", ".txt" };
            if (Array.IndexOf(allowedExtensions, fileInfo.Extension) < 0)
            {
                throw new Exception("File format not supported. Please upload a PDF, DOCX, or TXT file.");
            }

            // Simulate successful file upload
            Console.WriteLine("File uploaded successfully.");
        }
    }

    // Application Deadline Handling
    public class ApplicationDeadline
    {
        public static void CheckApplicationDeadline(DateTime deadline)
        {
            if (DateTime.Now > deadline)
            {
                throw new Exception("Application is no longer accepted. The deadline has passed.");
            }
        }
    }

    // Database Connection Handling
    public class DatabaseConnectionHandler
    {
        private string connectionString;

        public DatabaseConnectionHandler(string connString)
        {
            connectionString = connString;
        }

        public void RetrieveJobListings()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Simulate job listings retrieval
                    Console.WriteLine("Connected to the database and retrieved job listings.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
