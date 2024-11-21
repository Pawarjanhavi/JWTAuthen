using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Util
{
    public static class DBConnection
    {
        private static SqlConnection connection;

        // Method to get the SQL connection
        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                // Retrieve the connection string from DBPropertyUtil
                string connectionString = DBPropertyUtil.GetConnectionString("appsettings.json");
                connection = new SqlConnection(connectionString);
            }

            // Ensure the connection is open
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }

            return connection;
        }
    }
}
