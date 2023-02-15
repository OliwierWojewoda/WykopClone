using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WykopClone.Models;

namespace WykopClone.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Models.Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
