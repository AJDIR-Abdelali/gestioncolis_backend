using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class SecteurRepo : ISecteurRepo
    {
        private readonly GestionColisContext dbcontext;

        public SecteurRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Secteur> SecteurAsync(Secteur secteur)
        {
            await dbcontext.Secteurs.AddAsync(secteur);
            await dbcontext.SaveChangesAsync();
            return secteur;
        }

        public async Task<IEnumerable<Secteur>> GetAllSecteursAsync()
        {
            return await dbcontext.Secteurs.ToListAsync();
        }

        public async Task<Secteur?> GetById(int id)
        {
            return await dbcontext.Secteurs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Secteur?> DeleteAsync(int id)
        {
            var existingSecteur = await GetById(id);
            if (existingSecteur != null)
            {
                dbcontext.Secteurs.Remove(existingSecteur);
                await dbcontext.SaveChangesAsync();
                return existingSecteur;
            }
            return null;
        }

        public async Task<Secteur?> UpdateAsync(Secteur secteur)
        {
            var existingSecteur = await dbcontext.Secteurs.FirstOrDefaultAsync(x => x.Id == secteur.Id);
            if (existingSecteur != null)
            {
                dbcontext.Entry(existingSecteur).CurrentValues.SetValues(secteur);
                await dbcontext.SaveChangesAsync();
                return secteur;
            }
            return null;
        }
    }
}
