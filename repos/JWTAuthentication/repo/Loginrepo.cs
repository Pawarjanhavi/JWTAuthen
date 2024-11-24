using JWTAuthentication.Models;
using JWTAuthentication.Data;
using JWTAuthentication.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.repo
{
    public class Loginrepo : Service.ILoginService
    {
        private readonly ApplicationDBContext _dbContext;
        public Loginrepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;

        }

        public bool LoginUser(string userName, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == userName);

            if (user == null)
            {
                // Log or return false if no user is found with that email
                Console.WriteLine($"No user found with email: {userName}");
                return false;
            }

            // Compare passwords directly (case-sensitive)
            Console.WriteLine($"Comparing password: {password} with stored password: {user.Password}");

            if (user.Password == password)
            {
                return true; // Passwords match
            }
            else
            {
                // Log mismatch
                Console.WriteLine($"Password mismatch: {password} != {user.Password}");
                return false; // Password mismatch
            }
        }

    }
}
