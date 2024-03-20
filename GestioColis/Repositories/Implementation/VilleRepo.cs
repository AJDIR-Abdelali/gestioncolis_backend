using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class VilleRepo : IVilleRepo
    {
        private readonly GestionColisContext dbcontext;

        public VilleRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Ville> VilleAsync(Ville ville)
        {
            await dbcontext.Villes.AddAsync(ville);
            await dbcontext.SaveChangesAsync();
            return ville;
        }

        public async Task<IEnumerable<Ville>> GetAllVillesAsync()
        {
            return await dbcontext.Villes.ToListAsync();
        }

        public async Task<Ville?> GetById(int id)
        {
            return await dbcontext.Villes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ville?> DeleteAsync(int id)
        {
            var existingVille = await dbcontext.Villes.FirstOrDefaultAsync(x => x.Id == id);
            if (existingVille != null)
            {
                dbcontext.Villes.Remove(existingVille);
                await dbcontext.SaveChangesAsync();
                return existingVille;
            }
            return null;
        }

        public async Task<Ville?> UpdateAsync(Ville ville)
        {
            var existingVille = await dbcontext.Villes.FirstOrDefaultAsync(x => x.Id == ville.Id);
            if (existingVille != null)
            {
                dbcontext.Entry(existingVille).CurrentValues.SetValues(ville);
                await dbcontext.SaveChangesAsync();
                return ville;
            }
            return null;

        }

    }
}
