using C__REST_API_MySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace C__REST_API_MySQL.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }
        public DbSet<User> Users { get; set; }
    }
}
