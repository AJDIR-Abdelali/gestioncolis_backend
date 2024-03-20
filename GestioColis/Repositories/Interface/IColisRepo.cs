using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface IColisRepo
    {
        Task<Colis> ColisAsync(Colis colis);

        Task<IEnumerable<Colis>> GetAllColissAsync();

        Task<Colis?> GetById(Guid id);

        Task<Colis?> UpdateAsync(Colis colis);

        Task<Colis?> DeleteAsync(Guid id);
    }
}
