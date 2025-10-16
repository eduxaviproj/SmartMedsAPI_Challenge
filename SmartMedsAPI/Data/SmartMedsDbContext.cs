using Microsoft.EntityFrameworkCore;
using SmartMedsAPI.Models.Domain;

namespace SmartMedsAPI.Data
{
    public class SmartMedsDbContext : DbContext
    {
        public SmartMedsDbContext(DbContextOptions<SmartMedsDbContext> options) : base(options)
        {
        }

        public DbSet<Medication> Medications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data

        }

    }
}
