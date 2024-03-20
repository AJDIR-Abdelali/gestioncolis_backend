using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class SuivieRepo : ISuivieRepo
    {
        private readonly GestionColisContext dbcontext;

        public SuivieRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Suivie?> DeleteAsync(int id)
        {
            var existingSuivie = await dbcontext.Suivies.FirstOrDefaultAsync(x => x.Id == id);
            if(existingSuivie != null)
            {
                dbcontext.Suivies.Remove(existingSuivie);
                await dbcontext.SaveChangesAsync();
                return existingSuivie;
            }
            return null;
        }

        public async Task<IEnumerable<Suivie>> GetAllSuiviesAsync()
        {
            return await dbcontext.Suivies.ToListAsync();
        }

        public async Task<Suivie?> GetById(int id)
        {
            return await dbcontext.Suivies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Suivie> SuivieAsync(Suivie suivie)
        {
            await dbcontext.Suivies.AddAsync(suivie);
            await dbcontext.SaveChangesAsync();
            return suivie;
        }

        public async Task<Suivie?> UpdateAsync(Suivie suivie)
        {
            var existingSuivie = await dbcontext.Suivies.FirstOrDefaultAsync(a => a.Id == suivie.Id);
            if (existingSuivie != null)
            {
                dbcontext.Entry(existingSuivie).CurrentValues.SetValues(suivie);
                await dbcontext.SaveChangesAsync();
                return suivie;
            }
            return null;
        }
    }
}
