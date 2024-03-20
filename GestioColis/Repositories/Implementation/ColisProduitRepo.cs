using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class ColisProduitRepo : IColisProduitRepo
    {
        private readonly GestionColisContext dbcontext;

        public ColisProduitRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<ColisProduit> ColisProduitAsync(ColisProduit colisProduit)
        {
            await dbcontext.colisProduits.AddAsync(colisProduit);
            await dbcontext.SaveChangesAsync();
            return colisProduit;
        }

        public async Task<ColisProduit?> DeleteAsync(Guid id)
        {
            var existingColisProduit = await dbcontext.colisProduits.FirstOrDefaultAsync(x => x.Id == id);  
            if(existingColisProduit != null)
            {
                dbcontext.colisProduits.Remove(existingColisProduit);
                await dbcontext.SaveChangesAsync();
                return existingColisProduit;
            }
            return null;
        }

        public async Task<IEnumerable<ColisProduit>> GetAllColisProduitsAsync()
        {
            return await dbcontext.colisProduits.ToListAsync();
        }

        public async Task<ColisProduit?> GetById(Guid id)
        {
            return await dbcontext.colisProduits.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ColisProduit?> UpdateAsync(ColisProduit colisProduit)
        {
            var existingColisProduit = await dbcontext.colisProduits.FirstOrDefaultAsync(x => x.Id == colisProduit.Id);
            if (existingColisProduit != null)
            {
                dbcontext.Entry(existingColisProduit).CurrentValues.SetValues(colisProduit);
                await dbcontext.SaveChangesAsync();
                return colisProduit;
            }
            return null;

        }
    }
}
