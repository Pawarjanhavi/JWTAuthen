namespace BasicApiAuthentication.Model
{
    public interface IUserRepositry
    {

        Task<User> ValidateUser(string username, string password);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);

    }
}
