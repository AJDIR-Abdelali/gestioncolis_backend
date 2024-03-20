using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface ICommandeRepo
    {
        Task<Commande> CommandeAsync(Commande commande);

        Task<IEnumerable<Commande>> GetAllCommandesAsync();

        Task<Commande?> GetById(Guid id);

        Task<Commande?> UpdateAsync(Commande commande);

        Task<Commande?> DeleteAsync(Guid id);
    }
}
