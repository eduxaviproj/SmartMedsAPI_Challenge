using Microsoft.EntityFrameworkCore;
using SmartMedsAPI.Data;
using SmartMedsAPI.Models.Domain;
using SmartMedsAPI.Repositories.Interfaces;

namespace SmartMedsAPI.Repositories.Repos
{
    public class SQLiteMedicationRepos : IMedicationRepos
    {

        private readonly SmartMedsDbContext dbContext;
        public SQLiteMedicationRepos(SmartMedsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<Medication>> GetAllAsync()
        {
            var meds = dbContext.Medications.OrderBy(m => m.Id).ToListAsync();
            return meds;
        }

        public async Task<Medication> CreateAsync(Medication medication)
        {
            var medExists = await dbContext.Medications
                .AnyAsync(m => m.Name.ToLower() == medication.Name.ToLower());

            if (medExists)
            { return null; }

            dbContext.Medications.Add(medication);
            await dbContext.SaveChangesAsync();
            return medication;
        }

        public async Task<Medication?> DeleteAsync(Guid id)
        {
            var med = await dbContext.Medications.FindAsync(id);

            if (med == null)
            { return null; }

            dbContext.Medications.Remove(med);
            await dbContext.SaveChangesAsync();

            return med;
        }

    }
}
