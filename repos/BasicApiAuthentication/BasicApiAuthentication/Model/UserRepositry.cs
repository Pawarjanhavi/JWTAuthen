namespace BasicApiAuthentication.Model
{
    public class UserRepositry : IUserRepositry
    {
        private List<User> Users = new List<User>
        {
            new User(){Id=1,UserName = "Janhavi",Password="123"},
            new User(){Id=2,UserName = "Vaishali",Password="TTI"},
            new User(){Id=3,UserName = "Tejas",Password="TEJ"},
            new User(){Id=4,UserName = "Tanu",Password="345"},

        };

        public async Task<User>ValidateUser(string username, string password)
        {
            await Task.Delay(100);
            return Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public async Task<List<User>> GetAllUsers()
        {
            await Task.Delay(100);
            return Users.ToList();
        }

        public async Task<User> GetUserById(int id)
        {
            await Task.Delay(100);
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User>AddUser(User user)
        {
            await Task.Delay(100);
            if (Users.Any(user => user.Id == user.Id))
            {
                throw new Exception("User Id already exist"); 
            }
            Users.Add(user);
            return user;
        }

        public async Task<User>UpdateUser(User user)
        {
            await Task.Delay(100);
            var euser = await GetUserById(user.Id);
            if (euser == null) { throw new Exception("User to update not found"); }
            euser.UserName = user.UserName;
            euser.Password = user.Password;
            return euser;
        }

        public async Task DeleteUser(int id)
        {
            await Task.Delay(100);
            var euser = await GetUserById(id);
            if (euser == null)
            {
                throw new Exception("User to delete not found");
            }
            Users.Remove(euser);
            
            }
        }
    }

