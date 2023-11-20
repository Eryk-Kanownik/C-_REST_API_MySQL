using C__REST_API_MySQL.Models;
using Microsoft.AspNetCore.Mvc;
namespace C__REST_API_MySQL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int id,User user);
        Task<IEnumerable<User>> DeleteUser(int id);

    }
}
