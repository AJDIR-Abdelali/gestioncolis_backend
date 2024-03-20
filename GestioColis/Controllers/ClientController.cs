using GestioColis.Dto.Client;
using GestioColis.Models;
using GestioColis.Repositories.Implementation;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepo clientRepo;

        public ClientController(IClientRepo clientRepo)
        {
            this.clientRepo = clientRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequestDto request)
        {
            var client = new Client
            {
                Nom = request.Nom,
                Prenom = request.Prenom,
                Adresse = request.Adresse,
                Telephone = request.Telephone,
            };
            await clientRepo.ClientAsync(client);

            var response = new ClientDto
            {

                Nom = client.Nom,
                Prenom = client.Prenom,
                Adresse = client.Adresse,
                Telephone = client.Telephone
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await clientRepo.GetAllClientsAsync();

            var response = new List<ClientDto>();

            foreach (var client in clients)
            {
                response.Add(new ClientDto
                {
                    Id = client.Id,
                    Nom = client.Nom,
                    Prenom = client.Prenom,
                    Telephone = client.Telephone,
                    Adresse = client.Adresse,
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetClientById([FromRoute] Guid id)
        {
            var existingClient = await clientRepo.GetById(id);

            if (existingClient == null)
                return NotFound();

            var response = new ClientDto
            {
                Id = existingClient.Id,
                Nom = existingClient.Nom,
                Prenom = existingClient.Prenom,
                Adresse = existingClient.Adresse,
                Telephone = existingClient.Telephone,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditClient([FromRoute] Guid id, UpdateClientRequestDto request)
        {
            var client = new Client
            {
                Id = id,
                Nom = request.Nom,
                Prenom = request.Prenom,
                Adresse = request.Adresse,
                Telephone = request.Telephone,
            };

            client = await clientRepo.UpdateAsync(client);

            if (client == null)
                return NotFound();

            var response = new ClientDto
            {
                Id = client.Id,
                Nom = client.Nom,
                Prenom = client.Prenom,
                Adresse = client.Adresse,
                Telephone = client.Telephone
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteClient([FromRoute] Guid id)
        {
            var client = await clientRepo.DeleteAsync(id);

            if (client == null) return NotFound("Client with ID " + id + " does not exist or has been deleted.");

            var response = new ClientDto
            {
                Id = client.Id,
                Nom = client.Nom,
                Prenom = client.Prenom,
                Adresse = client.Adresse,
                Telephone = client.Telephone,
            };
            return Ok(response);
        }
    }
}
