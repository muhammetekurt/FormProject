using FormProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FormProject.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>()
                .Property(f => f.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
