using C__REST_API_MySQL.Data;
using C__REST_API_MySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace C__REST_API_MySQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User> CreateUser(User user)
        {
            _applicationDbContext.Users.Add(user);
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            var user = await _applicationDbContext.Users.FindAsync(id);
            if(user == null)
            {
                return null;
            }
            _applicationDbContext.Users.Remove(user);
            await _applicationDbContext.SaveChangesAsync();
            return await _applicationDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _applicationDbContext.Users.FindAsync(id);
            if(user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            List<User> users = await _applicationDbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> UpdateUser(int id,User user)
        {
            User exist = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (exist != null)
            {
                exist.FirstName = user.FirstName != exist.FirstName ? user.FirstName : exist.FirstName;
                exist.LastName = user.LastName != exist.LastName ? user.LastName : exist.LastName;
                exist.Email = user.Email != exist.Email ? user.Email : exist.Email;
                exist.Password = user.Password != exist.Password ? user.Password : exist.Password;
            }
            _applicationDbContext.Entry(exist).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }
    }
}
