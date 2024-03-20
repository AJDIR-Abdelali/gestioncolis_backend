using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface IColisProduitRepo
    {
        Task<ColisProduit> ColisProduitAsync(ColisProduit colisProduit);

        Task<IEnumerable<ColisProduit>> GetAllColisProduitsAsync();

        Task<ColisProduit?> GetById(Guid id);

        Task<ColisProduit?> UpdateAsync(ColisProduit colisProduit);

        Task<ColisProduit?> DeleteAsync(Guid id);
    }
}
