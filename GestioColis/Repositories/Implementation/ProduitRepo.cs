using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class ProduitRepo : IProduitRepo
    {
        private readonly GestionColisContext dbcontext;

        public ProduitRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Produit?> DeleteAsync(Guid id)
        {
            var existingProduit = await GetById(id);
            if (existingProduit != null)
            {
                dbcontext.Produits.Remove(existingProduit);
                await dbcontext.SaveChangesAsync();
                return existingProduit;
            } 
            return null;
        }

        public async Task<IEnumerable<Produit>> GetAllProduitsAsync()
        {
            return await dbcontext.Produits.ToListAsync();
        }

        public async Task<Produit?> GetById(Guid id)
        {
            return await dbcontext.Produits.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Produit> ProduitAsync(Produit produit)
        {
            await dbcontext.Produits.AddAsync(produit);
            await dbcontext.SaveChangesAsync();
            return produit;
        }

        public async Task<Produit?> UpdateAsync(Produit produit)
        {
            var existingProduit = await dbcontext.Produits.FirstOrDefaultAsync(p => p.Id ==  produit.Id);
            if(existingProduit != null)
            {
                dbcontext.Entry(existingProduit).CurrentValues.SetValues(produit);
                await dbcontext.SaveChangesAsync() ;
                return produit;
            }
            return null;
        }
    }
}
