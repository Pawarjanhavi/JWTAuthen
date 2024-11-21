using EMSModel;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!"); Employee employee = new Employee();
//Console.WriteLine("enter emp id");
//employee.Empid = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Etner name");
//employee.Ename = Console.ReadLine().Trim();
//Console.WriteLine("Enter Salary");
//employee.Sal=Convert.ToInt32(Console.ReadLine());
//double totalSal = employee.CalculateSalary(employee.Sal, 10000, 1000);
//Console.WriteLine($"Total SAlary= {totalSal}");

//double tax=employee.CalculateTax(employee.Sal);
//Console.WriteLine($"Tax paid= {tax}");
//double SalInHand=employee.CalculateSalaryAfterTax(employee.Sal);
//Console.WriteLine($"Salary in Hand = Rs. {SalInHand}");
//    Console.WriteLine("---------------------------------------");

HouseMaker hm = new HouseMaker();
Console.WriteLine("Enter Name");
hm.PersonName = Console.ReadLine();
Console.WriteLine("Enter pan");
hm.PanNo = Console.ReadLine();
Console.WriteLine("Enter aadhar");
hm.Aadhar = Convert.ToInt64(Console.ReadLine());
Console.WriteLine("Enter Passport");
hm.PassportNo = Convert.ToInt64(Console.ReadLine());
Console.WriteLine("Enter dob");
hm.DOB = Convert.ToDateTime(Console.ReadLine());

hm.PrintDetails();

Console.ReadKey();
