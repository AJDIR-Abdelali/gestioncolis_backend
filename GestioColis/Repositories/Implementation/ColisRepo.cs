using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class ColisRepo : IColisRepo
    {
        private readonly GestionColisContext dbcontext;

        public ColisRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Colis> ColisAsync(Colis colis)
        {
            await dbcontext.Colis.AddAsync(colis);
            await dbcontext.SaveChangesAsync();
            return colis;
        }

        public async Task<Colis?> DeleteAsync(Guid id)
        {
            var existingColis = await dbcontext.Colis.FirstOrDefaultAsync(c => c.Id == id);
            if (existingColis != null)
            {
                dbcontext.Colis.Remove(existingColis);
                await dbcontext.SaveChangesAsync();
                return existingColis;
            }
            return null;
        }

        public async Task<IEnumerable<Colis>> GetAllColissAsync()
        {
            return await
                dbcontext.Colis.ToListAsync();
        }

        public async Task<Colis?> GetById(Guid id)
        {
            return await dbcontext.Colis.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Colis?> UpdateAsync(Colis colis)
        {
            var existingColis = await dbcontext.Colis.FirstOrDefaultAsync(a => a.Id == colis.Id);
            if (existingColis != null)
            {
                dbcontext.Entry(existingColis).CurrentValues.SetValues(colis);
                await dbcontext.SaveChangesAsync();
                return colis;
            }
            return null;
        }
    }
}
