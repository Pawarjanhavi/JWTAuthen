using NUnit.Framework;
using HRLibrary;

namespace TestProject1
{
    [TestFixture]
    public class TestsForEmployeesOperationsBasic
    {
        [Test]
        public void TestForAdminLogin()
        {
          EmployeesOperations op=new EmployeesOperations();
          string admintest = op.Login("Admin", "Admin");
          Assert.IsEqual(admintest, "Welcome Admin");

        }
        [Test]
        public void TestForLoginWithWrongUserIDandPassword()
        {
         EmployeesOperations op = new EmployeesOperations();
          string testForUserGauri = op.Login("Gauri", "Gauri234");
         Assert.IsEqual(testForUserGauri, "Incorrect userid/password");


        }


        [Test]
        public void TestForLoginWithEmptyUSerIDPassword()
        {
            EmployeesOperations op = new EmployeesOperations();
            string testForEmpty = op.Login("", "");
            Assert.AreEqual(testForEmpty, "Userid or password cannot be empty or null");


        }


    }
}
