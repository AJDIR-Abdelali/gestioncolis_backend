using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class LivreurRepo :ILivreurRepo
    {
        private readonly GestionColisContext dbcontext;

        public LivreurRepo(GestionColisContext dbcontext) 
        {
            this.dbcontext = dbcontext;
        }
        public class MessageResult
        {
            public Livreur? Livreur { get; set; }
            public string Message { get; set; } = string.Empty;
        }


        public async Task<Livreur?> DeleteAsync(Guid id)
        {
            var existingLivreur = await GetById(id);
            if (existingLivreur != null)
            {
                dbcontext.Livreurs.Remove(existingLivreur);
                await dbcontext.SaveChangesAsync();
                return existingLivreur;
            }
            return null;
        }
        //just for test 
        public async Task<MessageResult> DeleteWithMessageAsync(Guid id)
        {
            var existingLivreur = await GetById(id);
            if (existingLivreur != null)
            {
                dbcontext.Livreurs.Remove(existingLivreur);
                await dbcontext.SaveChangesAsync();
                return new MessageResult { Livreur = existingLivreur, Message = "Livreur deleted successfully." };
            }
            return new MessageResult { Livreur = null, Message = "Livreur with ID " + id + " not found." };
        }
        //End just for test 

        public async Task<IEnumerable<Livreur>> GetAllLivreursAsync()
        {
            return await dbcontext.Livreurs.ToListAsync();
        }

        public async Task<Livreur?> GetById(Guid id)
        {
            return await dbcontext.Livreurs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Livreur> LivreurAsync(Livreur livreur)
        {
            await dbcontext.Livreurs.AddAsync(livreur);
            await dbcontext.SaveChangesAsync();
            return livreur;
        }

        public async Task<Livreur?> UpdateAsync(Livreur livreur)
        {
            var existingLivreur = await dbcontext.Livreurs.FirstOrDefaultAsync(x => x.Id == livreur.Id);
            if(existingLivreur != null)
            {
                dbcontext.Entry(existingLivreur).CurrentValues.SetValues(livreur);
                await dbcontext.SaveChangesAsync();
                return livreur;
            }
            return null;

        }
    }
}
