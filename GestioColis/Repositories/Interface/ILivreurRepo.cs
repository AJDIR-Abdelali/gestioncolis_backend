using GestioColis.Models;
using GestioColis.Repositories.Implementation;

namespace GestioColis.Repositories.Interface
{
    public interface ILivreurRepo
    {
        Task<Livreur> LivreurAsync(Livreur livreur);

        Task<IEnumerable<Livreur>> GetAllLivreursAsync();

        Task<Livreur?> GetById(Guid id);

        Task<Livreur?> UpdateAsync(Livreur livreur);

        Task<Livreur?> DeleteAsync(Guid id);

        Task<LivreurRepo.MessageResult> DeleteWithMessageAsync(Guid id);

    }
}
