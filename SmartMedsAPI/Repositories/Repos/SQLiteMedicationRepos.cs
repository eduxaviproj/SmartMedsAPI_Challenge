using SmartMedsAPI.Models.Domain;
using SmartMedsAPI.Repositories.Interfaces;

namespace SmartMedsAPI.Repositories.Repos
{
    public class SQLiteMedicationRepos : IMedicationRepos
    {
        public Task<Medication> CreateAsync(Medication medication)
        {
            throw new NotImplementedException();
        }

        public Task<Medication> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Medication>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
