using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
         // Register the user
        Task<User> Register(User user, string password);
         // Login user to the API
        Task<User> Login(string username, string password);
         // Check if the user exists
         Task<bool> UserExists(string username);
    }
}