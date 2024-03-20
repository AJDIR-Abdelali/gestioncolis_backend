using GestioColis.Data;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Repositories.Implementation
{
    public class ClientRepo : IClientRepo
    {
        private readonly GestionColisContext dbcontext;

        public ClientRepo(GestionColisContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Client> ClientAsync(Client client)
        {
            await dbcontext.Clients.AddAsync(client);
            await dbcontext.SaveChangesAsync();

            return client;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await dbcontext.Clients.ToListAsync();
        }

        public async Task<Client?> GetById(Guid id)
        {
            return await dbcontext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client?> DeleteAsync(Guid id)
        {
            var existingClient = await dbcontext.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (existingClient != null)
            {
                dbcontext.Clients.Remove(existingClient);
                await dbcontext.SaveChangesAsync();
                return existingClient;
            }
            return null;
        }

        public async Task<Client?> UpdateAsync(Client client)
        {
            var existingClient = await dbcontext.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            if (existingClient != null)
            {
                dbcontext.Entry(existingClient).CurrentValues.SetValues(client);
                await dbcontext.SaveChangesAsync();
                return client;
            }
            return null;
        }
    }
}
