using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class PaysRepo : IPaysRepo
    {
        private readonly GestionColisContext dbcontext;

        public PaysRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Pays?> GetById(int id)
        {
            return await dbcontext.Pays.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pays> PaysAsync(Pays pays)
        {
            await dbcontext.Pays.AddAsync(pays);
            await dbcontext.SaveChangesAsync();
            return pays;
        }

        public async Task<IEnumerable<Pays>> GetAllPaysAsync()
        {
            return await dbcontext.Pays.ToListAsync();
        }

        public async Task<Pays?> UpdateAsync(Pays pays)
        {
            var existingPays = await dbcontext.Pays.FirstOrDefaultAsync(x => x.Id == pays.Id);
            if (existingPays != null) {
                dbcontext.Entry(existingPays).CurrentValues.SetValues(pays);
                await dbcontext.SaveChangesAsync();
                return pays;
            }
            return null;
        }

        public async Task<Pays?> DeleteAsync(int id)
        {
            var existingPays = await dbcontext.Pays.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPays != null)
            {
                dbcontext.Pays.Remove(existingPays);
                await dbcontext.SaveChangesAsync();
                return existingPays;
            }
            return null;

        }
    }
}
