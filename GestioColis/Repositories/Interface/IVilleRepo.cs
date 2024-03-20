using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface IVilleRepo
    {
        Task<Ville> VilleAsync(Ville ville);

        Task<IEnumerable<Ville>> GetAllVillesAsync();

        Task<Ville?> GetById(int id);

        Task<Ville?> UpdateAsync(Ville ville);

        Task<Ville?> DeleteAsync(int id);

    }
}
