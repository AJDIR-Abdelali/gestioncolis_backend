using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface IStatutRepo
    {
        Task<Statut> StatutAsync(Statut statut);

        Task<IEnumerable<Statut>> GetAllStatutsAsync();

        Task<Statut?> GetById(int id);

        Task<Statut?> UpdateAsync(Statut statut);

        Task<Statut?> DeleteAsync(int id);
    }
}
