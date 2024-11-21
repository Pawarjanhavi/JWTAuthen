using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string fileName)
        {
            // Build the configuration from the JSON file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path to the current directory
                .AddJsonFile(fileName, optional: false, reloadOnChange: true); // Load the appsettings.json file

            IConfigurationRoot configuration = builder.Build();

            // Fetch the connection string from the configuration
            string connectionString = configuration.GetConnectionString("CourierDatabase");

            // If no connection string is found, throw an exception
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string not found in the configuration file.");
            }

            return connectionString;
        }
    }
}
