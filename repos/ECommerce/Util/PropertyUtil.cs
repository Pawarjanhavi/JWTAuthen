using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Util
{
    public static class PropertyUtil
    {
        // Method to get the connection string from the appsettings.json
        public static string GetPropertyString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // This should point to the correct path
                .AddJsonFile("C:\\Users\\ROG\\source\\repos\\ECommerce\\Util\\AppSettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("dbCn");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'dbCn' is not found in appsettings.json.");
            }

            return connectionString;
        }
    }
}
