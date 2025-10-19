using SmartMedsAPI.Models.Domain;

namespace SmartMedsAPI.Repositories.Interfaces
{
    public interface IMedicationRepos
    {
        Task<List<Medication>> GetAllAsync();
        Task<Medication> CreateAsync(Medication medication);
        Task DeleteAsync(Guid id);
    }
}
