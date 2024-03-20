using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class CommandeRepo : ICommandeRepo
    {
        private readonly GestionColisContext dbcontext;

        public CommandeRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Commande> CommandeAsync(Commande commande)
        {
            await dbcontext.Commandes.AddAsync(commande);
            await dbcontext.SaveChangesAsync();
            return commande;
        }

        public async Task<Commande?> DeleteAsync(Guid id)
        {
            var existingCommande = await dbcontext.Commandes.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCommande != null)
            {
                dbcontext.Commandes.Remove(existingCommande);
                await dbcontext.SaveChangesAsync();
                return existingCommande;
            }
            return null;
        }

        public async Task<IEnumerable<Commande>> GetAllCommandesAsync()
        {
            return await dbcontext.Commandes.ToListAsync();
        }

        public async Task<Commande?> GetById(Guid id)
        {
            return await dbcontext.Commandes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Commande?> UpdateAsync(Commande commande)
        {
            var existingCommande = await dbcontext.Commandes.FirstOrDefaultAsync(x =>  x.Id == commande.Id);
            if (existingCommande != null)
            {
                dbcontext.Entry(existingCommande).CurrentValues.SetValues(commande);
                await dbcontext.SaveChangesAsync() ;
                return commande;
            }
            return null;
        }
    }
}
