using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface IProduitRepo
    {
        Task<Produit> ProduitAsync(Produit produit);

        Task<IEnumerable<Produit>> GetAllProduitsAsync();

        Task<Produit?> GetById(Guid id);

        Task<Produit?> UpdateAsync(Produit produit);

        Task<Produit?> DeleteAsync(Guid id);
    }
}
