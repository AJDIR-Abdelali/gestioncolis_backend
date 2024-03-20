using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class StatutRepo : IStatutRepo
    {
        private readonly GestionColisContext dbcontext;

        public StatutRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Statut?> DeleteAsync(int id)
        {
            var existingStatut = await dbcontext.Statuts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStatut != null)
            {
                dbcontext.Statuts.Remove(existingStatut);
                await dbcontext.SaveChangesAsync();
                return (existingStatut);
            }
            return null;
        }

        public async Task<IEnumerable<Statut>> GetAllStatutsAsync()
        {
            return await dbcontext.Statuts.ToListAsync();
        }

        public async Task<Statut?> GetById(int id)
        {
            return await dbcontext.Statuts.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Statut> StatutAsync(Statut statut)
        {
            await dbcontext.Statuts.AddAsync(statut);
            await dbcontext.SaveChangesAsync ();
            return (statut);
        }

        public async Task<Statut?> UpdateAsync(Statut statut)
        {
            var existingStatut = await dbcontext.Statuts.FirstOrDefaultAsync(x => x.Id == statut.Id);
            if (existingStatut != null)
            {
                dbcontext.Entry(existingStatut).CurrentValues.SetValues(statut);
                await dbcontext.SaveChangesAsync();
                return statut;
            }
            return null;
        }
    }
}
