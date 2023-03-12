using TicTacToe.Model;

namespace TicTacToe.Services
{
    public interface IUsersService
    {
        Task AddUserAsync(string id, string name);
    }
    
    public class UsersService : IUsersService
    {
        private readonly HashSet<User> users = new HashSet<User>();



        public Task AddUserAsync(string id, string name)
        {
            users.Add(new User() { Id = id, Name = name });
            return Task.CompletedTask;
        }
    }
}
