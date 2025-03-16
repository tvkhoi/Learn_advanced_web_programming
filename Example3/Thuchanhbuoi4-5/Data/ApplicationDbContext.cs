using Microsoft.EntityFrameworkCore;
using Thuchanhbuoi4_5.Models;

namespace Thuchanhbuoi4_5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

}
