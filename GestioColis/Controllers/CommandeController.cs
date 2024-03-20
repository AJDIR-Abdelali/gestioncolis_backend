using GestioColis.Dto.Agence;
using GestioColis.Dto.Client;
using GestioColis.Dto.Commande;
using GestioColis.Dto.Livreur;
using GestioColis.Dto.Statuts;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly ICommandeRepo commandeRepo;
        private readonly IAgenceRepo agenceRepo;
        private readonly IStatutRepo statutRepo;
        private readonly ILivreurRepo livreurRepo;
        private readonly IClientRepo clientRepo;

        public CommandeController(
           ICommandeRepo commandeRepo,
           IAgenceRepo agenceRepo,
           IStatutRepo statutRepo,
           ILivreurRepo livreurRepo,
           IClientRepo clientRepo
           )
        {
            this.commandeRepo = commandeRepo;
            this.agenceRepo = agenceRepo;
            this.statutRepo = statutRepo;
            this.livreurRepo = livreurRepo;
            this.clientRepo = clientRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommande(
            [FromBody] CreateCommandeRequestDto request)
        {
            var commande = new Commande
            {
                Date = request.Date,
                montant_total = request.montant_total,
                DateRetour = request.DateRetour,
                DateChargement = request.DateChargement,
                Description = request.Description,
                ClientId = request.ClientId,
                AgenceId = request.AgenceId,
                LivreurId = request.LivreurId,
                StatutId = request.StatutId,
            };

            await commandeRepo.CommandeAsync(commande);

            var response = new CommandeDto
            {
                Id = commande.Id,
                Date = commande.Date,
                montant_total = commande.montant_total,
                DateRetour = commande.DateRetour,
                DateChargement = commande.DateChargement,
                Description = commande.Description,
                ClientId = commande.ClientId,
                AgenceId = commande.AgenceId,
                LivreurId = commande.LivreurId,
                StatutId = commande.StatutId,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSecteurs()
        {
            var commandes = await commandeRepo.GetAllCommandesAsync();
            var response = new List<CommandeDto>();

            foreach (var commande in commandes)
            {
                if (
                    commande.AgenceId != null &&
                    commande.ClientId != null &&
                    commande.LivreurId != null &&
                    commande.StatutId != null)
                {
                    var agence = await agenceRepo.GetById(commande.AgenceId);
                    var client = await clientRepo.GetById(commande.ClientId);
                    var livreur = await livreurRepo.GetById(commande.LivreurId);
                    var statut = await statutRepo.GetById(commande.StatutId);

                    var agenceDto = agence != null ? new AgenceDto
                    {
                        Id = agence.Id,
                        Nom = agence.Nom,
                    } : null;

                    var clientDto = client != null ? new ClientDto
                    {
                        Id = client.Id,
                        Nom = client.Nom,
                        Prenom = client.Prenom,
                    } : null;

                    var livreurDto = livreur != null ? new LivreurDto
                    {
                        Id = livreur.Id,
                        Nom = livreur.Nom,
                        Prenom = livreur.Prenom,
                    } : null;

                    var statutDto = statut != null ? new StatutDto
                    {
                        Id = statut.Id,
                        Nom = statut.Nom,
                    } : null;

                    response.Add(new CommandeDto
                    {
                        Id = commande.Id,
                        Date = commande.Date,
                        montant_total = commande.montant_total,
                        DateRetour = commande.DateRetour,
                        DateChargement = commande.DateChargement,
                        Description = commande.Description,
                        ClientId = commande.ClientId,
                        Client = clientDto,
                        AgenceId = commande.AgenceId,
                        Agence = agenceDto,
                        LivreurId = commande.LivreurId,
                        Livreur = livreurDto,
                        StatutId = commande.StatutId,
                        Statut = statutDto,
                    });
                }
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByCommandeId([FromRoute] Guid id)
        {
            var commande = await commandeRepo.GetById(id);
            AgenceDto? agenceDto = null;
            ClientDto? clientDto = null;
            LivreurDto? livreurDto = null;
            StatutDto? statutDto = null;
            if (commande == null) return NotFound();

            if(commande.AgenceId != null &&
                 commande.ClientId != null &&
                  commande.LivreurId != null &&
                  commande.StatutId != null)
            {
                var agence = await agenceRepo.GetById(commande.AgenceId);
                var client = await clientRepo.GetById(commande.ClientId);
                var livreur = await livreurRepo.GetById(commande.LivreurId);
                var statut = await statutRepo.GetById(commande.StatutId);

                agenceDto = agence != null ? new AgenceDto
                {
                    Id = agence.Id,
                    Nom = agence.Nom,
                } : null;

                clientDto = client != null ? new ClientDto
                {
                    Id = client.Id,
                    Nom = client.Nom,
                    Prenom = client.Prenom,
                } : null;

                livreurDto = livreur != null ? new LivreurDto
                {
                    Id = livreur.Id,
                    Nom = livreur.Nom,
                    Prenom = livreur.Prenom,
                } : null;

                statutDto = statut != null ? new StatutDto
                {
                    Id = statut.Id,
                    Nom = statut.Nom,
                } : null; 
            }
            var response = new CommandeDto
            {
                Id = commande.Id,
                Date = commande.Date,
                montant_total = commande.montant_total,
                DateRetour = commande.DateRetour,
                DateChargement = commande.DateChargement,
                Description = commande.Description,
                ClientId = commande.ClientId,
                Client = clientDto,
                AgenceId = commande.AgenceId,
                Agence = agenceDto,
                LivreurId = commande.LivreurId,
                Livreur = livreurDto,
                StatutId = commande.StatutId,
                Statut = statutDto,
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCommande([FromRoute] Guid id , UpdateCommandeRequestDto request)
        {
            var commande = new Commande
            {
                Id = id ,
                Date = request.Date,
                montant_total = request.montant_total,
                DateRetour = request.DateRetour,
                DateChargement = request.DateChargement,
                Description = request.Description,
                ClientId = request.ClientId,
                AgenceId = request.AgenceId,
                LivreurId = request.LivreurId,
                StatutId = request.StatutId,
            };
            commande = await commandeRepo.UpdateAsync(commande);

            if (commande == null) return NotFound();

            AgenceDto? agenceDto = null;
            ClientDto? clientDto = null;
            LivreurDto? livreurDto = null;
            StatutDto? statutDto = null;
            if (commande.AgenceId != null &&
                 commande.ClientId != null &&
                  commande.LivreurId != null &&
                  commande.StatutId != null)
            {
                var agence = await agenceRepo.GetById(commande.AgenceId);
                var client = await clientRepo.GetById(commande.ClientId);
                var livreur = await livreurRepo.GetById(commande.LivreurId);
                var statut = await statutRepo.GetById(commande.StatutId);

                agenceDto = agence != null ? new AgenceDto
                {
                    Id = agence.Id,
                    Nom = agence.Nom,
                } : null;

                clientDto = client != null ? new ClientDto
                {
                    Id = client.Id,
                    Nom = client.Nom,
                    Prenom = client.Prenom,
                } : null;

                livreurDto = livreur != null ? new LivreurDto
                {
                    Id = livreur.Id,
                    Nom = livreur.Nom,
                    Prenom = livreur.Prenom,
                } : null;

                statutDto = statut != null ? new StatutDto
                {
                    Id = statut.Id,
                    Nom = statut.Nom,
                } : null;
            }
            var response = new CommandeDto
            {
                Id = commande.Id,
                Date = commande.Date,
                montant_total = commande.montant_total,
                DateRetour = commande.DateRetour,
                DateChargement = commande.DateChargement,
                Description = commande.Description,
                ClientId = commande.ClientId,
                Client = clientDto,
                AgenceId = commande.AgenceId,
                Agence = agenceDto,
                LivreurId = commande.LivreurId,
                Livreur = livreurDto,
                StatutId = commande.StatutId,
                Statut = statutDto,
            };
            return Ok(response);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCommande([FromRoute] Guid id)
        {
            var commande = await commandeRepo.DeleteAsync(id);
            if (commande == null) return BadRequest();
            var response = new AgenceDto
            { 
                Id = commande.Id, 
            };
            return Ok(response);
        }

    }
}