namespace HRLibrary
{
    public class EmployeeDetails
    {

        public int id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
    }

    public class EmployeesOperations
    {

        public string Login(string userid, string password)
        {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(password))
            {

                return "Userid or password cannot be empty or null";
            }
            else
            {
                if (userid == "Admin" && password == "Admin")
                {
                    return "Welcome Admin";

                }
                return "Incorrect userid/password";

            }

        }

        public List<EmployeeDetails> AllUsers()
        {
            List<EmployeeDetails> emplist = new List<EmployeeDetails>();
            emplist.Add(new EmployeeDetails { id = 1, Name = "Ana", Gender = "Female", Salary = 10000 });
            emplist.Add(new EmployeeDetails { id = 2, Name = "Sima", Gender = "Female", Salary = 20000 });
            emplist.Add(new EmployeeDetails { id = 3, Name = "Ahana", Gender = "Female", Salary = 30000 });
            emplist.Add(new EmployeeDetails { id = 4, Name = "Jiten", Gender = "Male", Salary = 30000 });
            emplist.Add(new EmployeeDetails { id = 5, Name = "Miten", Gender = "Male", Salary = 25000 });

            return emplist;

        }

        public EmployeeDetails GetEmployee(int empid)
        {


            List<EmployeeDetails> alluserDetails = AllUsers();

            EmployeeDetails empData = alluserDetails.Find(e => e.id == empid);
            return empData;

        }

    }
}