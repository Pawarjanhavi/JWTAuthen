using System;
using Exceptionlib;


namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Simulate withdrawal with an invalid tracking number
                WithdrawAmount("0000"); // Change this number to simulate different scenarios

                // Simulate checking employee ID
                CheckEmployeeId(999); // Change this number to simulate different scenarios
            }
            catch (TrackingNumberNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidEmployeeIdException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction process completed.");
            }
        }

        static void WithdrawAmount(string trackingNumber)
        {
            // Assuming "0000" is an invalid tracking number
            if (trackingNumber == "0000")
            {
                throw new TrackingNumberNotFoundException("Tracking number not found for withdrawal or transfer.");
            }
            Console.WriteLine("Withdrawal successful.");
        }

        static void CheckEmployeeId(int employeeId)
        {
            // Assuming 999 is an invalid employee ID
            if (employeeId == 999)
            {
                throw new InvalidEmployeeIdException("Employee ID is invalid and does not exist in the system.");
            }
            Console.WriteLine("Employee ID is valid.");
        }
    }
}
