using APIS.Models;
using Microsoft.EntityFrameworkCore;

namespace APIS.Data
{
    public class UsersAPIDbContext : DbContext
    {
        public UsersAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> User { get; set; }


    }
}
