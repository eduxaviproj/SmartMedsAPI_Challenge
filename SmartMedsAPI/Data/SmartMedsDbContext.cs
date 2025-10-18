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
            base.OnModelCreating(modelBuilder);

            var createdAt = new DateTime(2025, 10, 17, 18, 30, 0, DateTimeKind.Utc);

            // seed medications to test
            modelBuilder.Entity<Medication>().HasData(
                new Medication
                {
                    Id = Guid.Parse("badc6845-6d80-4b28-bff6-7d8ddd361fb6"),
                    Name = "Aspirin",
                    Quantity = 30,
                    CreatedAt = createdAt
                },
                new Medication
                {
                    Id = Guid.Parse("fa8aad6a-d93a-4ed3-943c-684502e5ecbf"),
                    Name = "Ibuprofen",
                    Quantity = 20,
                    CreatedAt = createdAt
                }
            );


        }

    }
}
