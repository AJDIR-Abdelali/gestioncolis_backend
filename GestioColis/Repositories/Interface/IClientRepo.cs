using GestioColis.Models;

namespace GestioColis.Repositories.Interface
{
    public interface IClientRepo
    {
        Task<Client> ClientAsync(Client client);

        Task<IEnumerable<Client>> GetAllClientsAsync();

        Task<Client?> GetById(Guid id);

        Task<Client?> UpdateAsync(Client client);

        Task<Client?> DeleteAsync(Guid id);
    }
}
