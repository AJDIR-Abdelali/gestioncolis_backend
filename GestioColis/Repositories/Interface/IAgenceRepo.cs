using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface IAgenceRepo
    {
        Task<Agence> AgenceAsync(Agence agence);

        Task<IEnumerable<Agence>> GetAllAgencesAsync();

        Task<Agence?> GetById(Guid id);

        Task<Agence?> UpdateAsync(Agence agence);

        Task<Agence?> DeleteAsync(Guid id);
    }
}
