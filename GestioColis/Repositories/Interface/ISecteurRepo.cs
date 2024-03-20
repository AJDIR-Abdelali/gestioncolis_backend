using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface ISecteurRepo
    {
        Task<Secteur> SecteurAsync(Secteur secteur);

        Task<IEnumerable<Secteur>> GetAllSecteursAsync();

        Task<Secteur?> GetById(int id);

        Task<Secteur?> UpdateAsync(Secteur secteur);

        Task<Secteur?> DeleteAsync(int id);
    }
}
