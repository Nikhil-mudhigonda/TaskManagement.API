using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TaskManagement.API.Models;

namespace TaskManagement.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TaskItems> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>()
                .Property(x => x.isActive)
                .HasDefaultValue(true);
        }
    }
}
