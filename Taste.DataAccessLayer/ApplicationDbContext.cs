using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taste.Models;

namespace Taste.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<FoodType> FoodTypes { get; set; }
        
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
