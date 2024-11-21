internal class Program
{
 
        private static void Main(string[] args)
        {
            //task1
            // 1. Check Order Status
            Console.WriteLine("Order Status (Processing, Delivered, Cancelled):");
            string OrderStatus = Console.ReadLine();

            if (OrderStatus == "Delivered")
            {
                Console.WriteLine("The order has been delivered");
            }
            else if (OrderStatus == "Processing")
            {
                Console.WriteLine("The order is being processed");
            }
            else if (OrderStatus == "Cancelled")
            {
                Console.WriteLine("The order is Cancelled");
            }
            else
            {
                Console.WriteLine("No valid status provided");
            }
            Console.WriteLine("_________________________");

            // 2. Categorize parcels by weight
            Console.WriteLine("Enter the weight of the parcel:");
            double weight = Convert.ToDouble(Console.ReadLine());

            int category = 0;

            if (weight <= 1.0) // light
            {
                category = 0;
            }
            else if (weight > 1.0 && weight <= 5.0) // medium
            {
                category = 1;
            }
            else if (weight > 5.0) // heavy
            {
                category = 2;
            }

            switch (category)
            {
                case 0:
                    Console.WriteLine("The parcel is Light Weight");
                    break;
                case 1:
                    Console.WriteLine("The parcel is Medium Weight");
                    break;
                case 2:
                    Console.WriteLine("The parcel is Heavy");
                    break;
                default:
                    Console.WriteLine("Invalid category");
                    break;
            }
            Console.WriteLine("_________________________");

            // 3. User Authentication
            Console.WriteLine("Login System");
            Console.WriteLine("Are you an Employee (E) or Customer (C) :");
            char role = Convert.ToChar(Console.ReadLine());

            // Store employee and customer credentials
            var EmployeeCredentials = new (string Username, string Password)[]
            {
            ("Janhavi", "RJ12"),
            ("Vaishnavi", "V123")
            };

            var CustomerCredentials = new (string Username, string Password)[]
            {
            ("Rohit", "JSP"),
            ("Sham", "SHN1")
            };

            Console.WriteLine("Enter your Username:");
            string Username = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            if (role == 'E' || role == 'e')
            {
                bool validEmployee = false;
                foreach (var emp in EmployeeCredentials)
                {
                    if (Username == emp.Username && password == emp.Password)
                    {
                        validEmployee = true;
                        Console.WriteLine("\nWelcome " + Username + "\nYou Logged in Successfully");
                        break;
                    }
                }
                if (!validEmployee)
                {
                    Console.WriteLine("Invalid Credentials");
                }
            }
            else if (role == 'C' || role == 'c')
            {
                bool validCustomer = false;
                foreach (var cust in CustomerCredentials)
                {
                    if (Username == cust.Username && password == cust.Password)
                    {
                        validCustomer = true;
                        Console.WriteLine("\nWelcome " + Username + "\nYou Logged in Successfully");
                        break;
                    }
                }
                if (!validCustomer)
                {
                    Console.WriteLine("Invalid Credentials");
                }
            }
            else
            {
                Console.WriteLine("Invalid Entry");
            }
            Console.WriteLine("_________________________");

            /*//task2
            // 4. Display Customer Orders
            List<(int orderid, int customerid, string orderdetails)> orders = new List<(int, int, string)>
            {
                (1, 101, "Courier from City A to City B"),
                (2, 102, "Courier from City C to City D"),
                (3, 101, "Courier from City E to City F"),
                (4, 103, "Courier from City G to City H"),
                (5, 101, "Courier from City I to City J")
            };

            Console.WriteLine("Enter CustomerID to display their orders:");
            int customerid = int.Parse(Console.ReadLine());

            Console.WriteLine($"Orders for CustomerID {customerid}: ");
            int count = 0;
            foreach (var order in orders)
            {
                if (order.customerid == customerid)
                {
                    Console.WriteLine($"Order ID: {order.orderid}, Details: {order.orderdetails}");
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("No order");
            }
            Console.WriteLine("_________________________");


            //Task 3: Arrays and Data Structures
            //  Tracking Location of a Courier

            /*
                    Console.WriteLine("Tracking History:");

                    // Create a simple array to store the tracking history of a parcel
                    string[] trackingHistory = new string[3];
                    trackingHistory[0] = "Sender Location , 2024-10-01 10:00:00";
                    trackingHistory[1] = "In Transit , 2024-10-05 13:15:00";
                    trackingHistory[2] = "Receiver's Location , 2024-10-15 12:45:00";

                    // Display the tracking history
                    foreach (var update in trackingHistory)
                    {
                        Console.WriteLine(update);
                    }*/

            //8. Implement a method to find the nearest available courier for a new order using an array of couriers. 

            // Array of couriers using tuples
            /* var couriers = new (string Name, double Latitude, double Longitude, bool IsAvailable)[]
             {
                 ("Courier A", 37.7749, -122.4194, true),
                 ("Courier B", 40.7128, -74.0060, false),
                 ("Courier C", 34.0522, -118.2437, true)
             };

             // Find the nearest available courier based on the user's location
             var nearest = FindNearestCourier(couriers, 36.7783, -119.4179);  // Example user's location

             // Output the result
             if (nearest != null)
                 Console.WriteLine("Nearest available courier: " + nearest.Value.Name);
             else
                 Console.WriteLine("No available couriers.");
         }

         // Method to find the nearest available courier

         static (string Name, double Latitude, double Longitude, bool IsAvailable)? FindNearestCourier(
             (string Name, double Latitude, double Longitude, bool IsAvailable)[] couriers,
             double userLat,double userLon)

         {
             (string Name, double Latitude, double Longitude, bool IsAvailable)? nearest = null;  // To store the nearest available courier
             double minDistance = double.MaxValue;  // Start with a large number for the minimum distance

             foreach (var courier in couriers)  // Loop through all couriers
             {
                 if (!courier.IsAvailable)  // Skip if the courier is not available
                     continue;

                 // Calculate the distance using the Euclidean distance formula
                 double distance = Math.Sqrt(
                     Math.Pow(courier.Latitude - userLat, 2) +
                     Math.Pow(courier.Longitude - userLon, 2));

                 // If this courier is closer, update the nearest courier and the minimum distance
                 if (distance < minDistance)
                 {
                     minDistance = distance;
                     nearest = courier;
                 }
             }

             return nearest;
            */


            //Task 4: Strings,2d Arrays, user defined functions,Hashmap 
            //9. Parcel Tracking:


            /* string[,] parcels = new string[,]
             {
                 {"T01","Parcel in transit" },
                 {"T02","Parcel out for delivery" },
                 {"T03","Parcel delivered" },
                 {"T04","Parcel in transit" }

             };
             Console.Write("Enter the tracking number: ");
             string inputTrackingNumber = Console.ReadLine();

             // Search for the tracking number in the array
             bool found = false;
             for (int i = 0; i < parcels.GetLength(0); i++)
             {
                 if (parcels[i, 0] == inputTrackingNumber)
                 {
                     // Display the status of the parcel
                     Console.WriteLine("Tracking Number: " + parcels[i, 0] + " - Status: " + parcels[i, 1]);
                     found = true;
                     break;
                 }
             }

             // If the tracking number was not found
             if (!found)
             {
                 Console.WriteLine("Tracking number not found.");
             }
            */

            //10. Customer Data Validation


            /*bool ValidateCustomerData(string data, string details)
            {
                if (details == "name")
                {
                    // Name should start with an uppercase letter and the rest should be letters
                    if (char.IsUpper(data[0]))
                    {
                        for (int i = 1; i < data.Length; i++) // Start loop from index 1
                        {
                            if (!char.IsLetter(data[i]) || char.IsUpper(data[i]))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    return false;
                }
                else if (details == "address")
                {
                    // Validate address (allow letters, spaces, and commas)
                    foreach (char c in data)
                    {
                        if (!char.IsLetter(c) && c != ' ' && c != ',')
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else if (details == "phone number")
                {
                    // Validate phone number format (XXX-XXX-XXXX)
                    if (data.Length == 12 && data[3] == '-' && data[7] == '-')
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (i == 3 || i == 7) continue; // Skip hyphens
                            if (!char.IsDigit(data[i])) // Ensure remaining characters are digits
                                return false;
                        }
                        return true;
                    }
                    return false;
                }
                else
                {
                    // Handle invalid type
                    Console.WriteLine("Invalid details type.");
                    return false;
                }
            }
            Console.WriteLine("Enter the type of detail to validate (name, address, phone number): ");
            string detailType = Console.ReadLine().ToLower(); // Take input and convert to lowercase

            // Ensure the detailType is either name, address, or phone number
            if (detailType != "name" && detailType != "address" && detailType != "phone number")
            {
                Console.WriteLine("Invalid details type.");
                return;
            }

            Console.WriteLine($"Enter the {detailType} to validate: ");
            string userInput = Console.ReadLine(); // Take input for the detail

            // Validate user input
            bool isValid = ValidateCustomerData(userInput, detailType);

            // Output the result
            if (isValid)
            {
                Console.WriteLine($"{detailType} is valid.");
            }
            else
            {
                Console.WriteLine($"{detailType} is invalid.");
            }
            */


            //Address Formatting

            /*Console.WriteLine("Enter the address:");
            string Address = Console.ReadLine();

            Console.WriteLine("Enter the City:");
            string City = Console.ReadLine();

            Console.WriteLine("Enter the State:");
            string State = Console.ReadLine();

            Console.WriteLine("Enter the zip code:");
            string zipCode = Console.ReadLine();

            // Renaming the local variable to avoid conflict with the method name
            string formattedAddress = FormatAddress(Address, City, State, zipCode);
            Console.WriteLine("\nFormatted Address:");
            Console.WriteLine(formattedAddress);

            // Function to format the entire address
            string FormatAddress(string address, string city, string state, string zipCode)
            {
                address = CapitalizeWords(address);
                city = CapitalizeWords(city);
                state = CapitalizeWords(state);
                zipCode = FormatZipCode(zipCode);

                return $"{address}, {city}, {state} {zipCode}";
            }

            // Function to capitalize words
            string CapitalizeWords(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return input;

                string[] words = input.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (!string.IsNullOrEmpty(words[i]))
                    {
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                    }
                }

                return string.Join(" ", words);
            }

            // Function to format the zip code
            string FormatZipCode(string zipCode)
            {
                if (string.IsNullOrWhiteSpace(zipCode))
                    return zipCode;

                zipCode = zipCode.Replace("-", "").Trim();
                return zipCode.Length == 9 ? $"{zipCode.Substring(0, 5)}-{zipCode.Substring(5, 4)}" : zipCode;
            }*/

            //. Order Confirmation Email: 

            /*Console.WriteLine("Enter Customer Name :");
            string Customername = Console.ReadLine();

            Console.WriteLine("Enter Order Number :");
            string OrderNumber = Console.ReadLine();

            Console.WriteLine("Enter Delivery Address :");
            string DeliveryAddress = Console.ReadLine();

            Console.WriteLine("Enter City :");
            string City = Console.ReadLine();

            Console.WriteLine("Enter State :");
            string State = Console.ReadLine();

            Console.WriteLine("Enter Zip Code :");
            string ZipCode = Console.ReadLine();

            Console.WriteLine("Enter Expected Delivery Date(MM/DD/YYYY) :");
            string ExpectedDeliveryDate = Console.ReadLine();

            string EmailMessage = GenerateOrderConfirmationMail(Customername, OrderNumber, DeliveryAddress, City, State, ZipCode, ExpectedDeliveryDate);

            Console.WriteLine("\nOrder Confirmation Email :");
            Console.WriteLine(EmailMessage);


            String GenerateOrderConfirmationMail(string Customername, string OrderNumber, string DeliveryAddress, string City, string State, string ZipCode, string ExpectedDeliveryDate)
            {
                string Email = $"Dear {Customername},\n\n" +
                           $"Thank you for ordering from us!\n\n" +
                           $"Order Number: {OrderNumber}\n" +
                           $"Delivery Address: {DeliveryAddress}, {City}, {State} {ZipCode}\n" +
                           $"Expected Delivery Date: {ExpectedDeliveryDate}\n\n" +
                           $"Looking forward to delivering your order.";
                return Email;

            }
            */

            //Calculate Shipping Cost
            /*
                   // Prompt for source address
                   Console.WriteLine("Enter the Sender's Address:");
                   string sourceAddress = Console.ReadLine();

                   // Prompt for destination address
                   Console.WriteLine("Enter the Receiver's Address:");
                   string destinationAddress = Console.ReadLine();

                   // Prompt for distance
                   Console.WriteLine("Enter the Distance (in kilometers):");
                   string distanceInput = Console.ReadLine();
                   double distance;

                   // Try to parse the distance input
                   if (!double.TryParse(distanceInput, out distance) || distance <= 0)
                   {
                       Console.WriteLine("Invalid distance entered. Please enter a positive number.");
                       return;
                   }

                   // Prompt for weight of the parcel
                   Console.WriteLine("Enter the weight of the parcel:");
                   string weightInput = Console.ReadLine();
                   double weight;

                   // Try to parse the weight input
                   if (!double.TryParse(weightInput, out weight) || weight <= 0)
                   {
                       Console.WriteLine("Invalid weight entered. Please enter a positive number.");
                       return;
                   }

                   // Calculate shipping cost
                   double shippingCost = CalculateShippingCost(distance, weight);
                   Console.WriteLine($"The shipping cost from {sourceAddress} to {destinationAddress} is: Rs{shippingCost:F2}");


               // Function to calculate shipping cost
                double CalculateShippingCost(double distance, double weight)
               {
                   // Assume a base rate and a rate per kilometer and per kg
                   const double baseRate = 50.00; // Base shipping cost
                   const double ratePerKm = 10.00; // Cost per kilometer
                   const double ratePerKg = 15.00; // Cost per kilogram

                   // Calculate total shipping cost
                   double totalCost = baseRate + (ratePerKm * distance) + (ratePerKg * weight);
                   return totalCost;
               }
            */

            // Password Generator

            /* Console.WriteLine("Enter the desired password length (minimum 8 characters):");
              if (int.TryParse(Console.ReadLine(), out int passwordLength) && passwordLength >= 8)
              {
                   string generatedPassword = GenerateSecurePassword(passwordLength);
                   Console.WriteLine($"Generated secure password: {generatedPassword}");
              }
              else
              {
                   Console.WriteLine("Please enter a valid password length of at least 8 characters.");
              }

             string GenerateSecurePassword(int length)
             {
                 const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                 const string lowercase = "abcdefghijklmnopqrstuvwxyz";
                 const string numbers = "0123456789";
                 const string specialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?";

                 // Ensure password contains at least one character from each category
                 Random random = new Random();
                 StringBuilder password = new StringBuilder();

                 password.Append(uppercase[random.Next(uppercase.Length)]);
                 password.Append(lowercase[random.Next(lowercase.Length)]);
                 password.Append(numbers[random.Next(numbers.Length)]);
                 password.Append(specialCharacters[random.Next(specialCharacters.Length)]);

                 // Fill the rest of the password length with a random mix
                 string allCharacters = uppercase + lowercase + numbers + specialCharacters;

                 for (int i = 4; i < length; i++)
                 {
                     password.Append(allCharacters[random.Next(allCharacters.Length)]);
                 }

                 return password.ToString();
             }*/

            //find similar Address

            /*List<string> addresses = new List<string>
            {
                "Kalika Nagar, Kopargaon",
                "Kalika Nagar, Kopargaon",
                "Pimpri Chinchwad, Pune",
                "Pimpri Chinchwad, Pune, Maharashtra"

            };

            var similarAddresses = FindSimilarAddresses(addresses);
            foreach (var pair in similarAddresses)
            {
                Console.WriteLine($"Similar Addresses: \n1. {pair.Item1} \n2. {pair.Item2}\n");
            }

            List<Tuple<string, string>> FindSimilarAddresses(List<string> addresses)
            {
                var similarPairs = new List<Tuple<string, string>>();

                for (int i = 0; i < addresses.Count; i++)
                {
                    for (int j = i + 1; j < addresses.Count; j++)
                    {
                        // Normalize both addresses: trim spaces and convert to lowercase
                        string normalizedAddress1 = addresses[i].Trim().ToLower();
                        string normalizedAddress2 = addresses[j].Trim().ToLower();

                        // Compare normalized addresses
                        if (string.Equals(normalizedAddress1, normalizedAddress2))
                        {
                            similarPairs.Add(new Tuple<string, string>(addresses[i], addresses[j]));
                        }
                    }
                }

                return similarPairs;

            }
            */


            //




        }
}





