using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface ISuivieRepo
    {
        Task<Suivie> SuivieAsync(Suivie suivie);

        Task<IEnumerable<Suivie>> GetAllSuiviesAsync();

        Task<Suivie?> GetById(int id);

        Task<Suivie?> UpdateAsync(Suivie suivie);

        Task<Suivie?> DeleteAsync(int id);
    }
}
