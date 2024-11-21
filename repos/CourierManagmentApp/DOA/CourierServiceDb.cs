using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;

namespace DOA
{
    public class CourierServiceDb
    {
        private static SqlConnection connection;

        public CourierServiceDb()
        {
            // Use the GetConnection method from DBConnection class
            connection = Util.DBConnection.GetConnection();
        }

        // Example method to insert a courier into the database
        public void InsertCourier(Courier courier)
        {
            string query = "INSERT INTO Couriers (TrackingNumber, Status) VALUES (@TrackingNumber, @Status)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@TrackingNumber", courier.TrackingNumber);
                cmd.Parameters.AddWithValue("@Status", courier.Status);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Courier inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting courier: {ex.Message}");
                }
            }
        }
    }
}
