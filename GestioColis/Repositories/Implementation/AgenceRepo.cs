using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace GestioColis.Repositories.Implementation
{
    public class AgenceRepo : IAgenceRepo
    {
        private readonly GestionColisContext dbcontext;

        public AgenceRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Agence> AgenceAsync(Agence agence)
        {
            await dbcontext.Agences.AddAsync(agence);
            await dbcontext.SaveChangesAsync();
            return agence;
        }

        public async Task<Agence?> DeleteAsync(Guid id)
        {
            var existingAgence = await dbcontext.Agences.FirstOrDefaultAsync(x => x.Id == id);  
            if (existingAgence != null)
            {
                dbcontext.Agences.Remove(existingAgence);
                await dbcontext.SaveChangesAsync();
                return existingAgence;
            }
            return null;
        }

        public async Task<IEnumerable<Agence>> GetAllAgencesAsync()
        {
            return await dbcontext.Agences.ToListAsync();
        }

        public async Task<Agence?> GetById(Guid id)
        {
            return await dbcontext.Agences.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Agence?> UpdateAsync(Agence agence)
        {
            var existingAgence = await dbcontext.Agences.FirstOrDefaultAsync(a => a.Id == agence.Id);
            if (existingAgence != null)
            {
                dbcontext.Entry(existingAgence).CurrentValues.SetValues(agence);
                await dbcontext.SaveChangesAsync();
                return agence;
            }
            return null;
        }
    }
}
