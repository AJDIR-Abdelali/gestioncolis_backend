using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface IPaysRepo
    {
        Task<Pays> PaysAsync(Pays pays);

        Task<IEnumerable<Pays>> GetAllPaysAsync();

        Task<Pays?> GetById(int id);

        Task<Pays?> UpdateAsync(Pays pays);

        Task<Pays?> DeleteAsync(int id);
    }
}
