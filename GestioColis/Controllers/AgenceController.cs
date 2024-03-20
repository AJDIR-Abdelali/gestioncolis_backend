    using GestioColis.Dto.Agence;
using GestioColis.Dto.Livreur;
using GestioColis.Dto.Ville;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenceController : ControllerBase
    {
        private readonly IAgenceRepo agenceRepo;
        private readonly IVilleRepo villeRepo;
        private readonly ILivreurRepo livreurRepo;

        public AgenceController(
            IAgenceRepo agenceRepo , 
            IVilleRepo villeRepo , 
            ILivreurRepo livreurRepo)
        {
            this.agenceRepo = agenceRepo;
            this.villeRepo = villeRepo;
            this.livreurRepo = livreurRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgence([FromBody] CreateAgenceRequestDto request)
        {
            var agence = new Agence
            {
                Nom = request.Nom,
                Adresse = request.Adresse,
                Email = request.Email,
                Telephone = request.Telephone,
                VilleId = request.VilleId,
                LivreurId = request.LivreurId,
            };
            await agenceRepo.AgenceAsync(agence);

            var response = new AgenceDto
            {
                Nom = agence.Nom,
                Adresse = agence.Adresse,
                Email = agence.Email,
                Telephone = agence.Telephone,
                VilleId = agence.VilleId,
                LivreurId = agence.LivreurId,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAgences()
        {
            var agences = await agenceRepo.GetAllAgencesAsync();
            var response = new List<AgenceDto>();

            foreach (var agence in agences)
            {
                if(agence.VilleId != null && agence.LivreurId != null)
                {
                    var ville = await villeRepo.GetById(agence.VilleId);
                    var villeDto = ville != null ? new VilleDto
                    {
                        Nom = ville.Nom,
                    } : null;

                    var livreur = await livreurRepo.GetById(agence.LivreurId);
                    var livreurDto = livreur != null ? new LivreurDto
                    {
                        Nom = livreur.Nom,
                        Prenom = livreur.Prenom,
                    } : null;

                    response.Add(new AgenceDto
                    {
                        Id = agence.Id,
                        Nom = agence.Nom,
                        Adresse = agence.Adresse,
                        Telephone = agence.Telephone,
                        Email = agence.Email,
                        VilleId = agence.VilleId,
                        Ville = villeDto,
                        LivreurId = agence.LivreurId,
                        Livreur = livreurDto,
                    });
                }
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAgenceById([FromRoute] Guid id)
        {
            var existingAgence = await agenceRepo.GetById(id);
            if (existingAgence == null) return NotFound();
            VilleDto? villeDto = null;
            LivreurDto? livreurDto = null;
            if (existingAgence.VilleId != null && existingAgence.LivreurId != null)
            {
                var ville = await villeRepo.GetById(existingAgence.VilleId);
                villeDto = ville != null ? new VilleDto
                {
                    Nom = ville.Nom,
                } : null;

                var livreur = await livreurRepo.GetById(existingAgence.LivreurId);
                livreurDto = livreur != null ? new LivreurDto
                {
                    Nom = livreur.Nom,
                    Prenom = livreur.Prenom,
                } : null;
            }
            var response = new AgenceDto
            {
                Id = existingAgence.Id,
                Nom = existingAgence.Nom,
                Adresse = existingAgence.Adresse,
                Telephone = existingAgence.Telephone,
                Email = existingAgence.Email,
                LivreurId = existingAgence.LivreurId,
                VilleId = existingAgence.VilleId,
                Ville = villeDto,
                Livreur = livreurDto,
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAgence([FromRoute] Guid id , UpdateAgenceRequestDto request)
        {
            var agence = new Agence
            {
                Id = id ,
                Nom = request.Nom ,
                Adresse = request.Adresse ,
                Telephone = request.Telephone ,
                Email = request.Email ,
                VilleId = request.VilleId ,
                LivreurId = request.LivreurId ,
            };
            agence = await agenceRepo.UpdateAsync(agence);
            if (agence == null) return NotFound();

            VilleDto? villeDto = null;
            LivreurDto? livreurDto = null;

            if(agence.VilleId != null && agence.LivreurId != null)
            {
                var ville = await villeRepo.GetById(agence.VilleId);
                villeDto = ville != null ? new VilleDto
                {
                    Nom = ville.Nom,
                } : null;

                var livreur = await livreurRepo.GetById(agence.LivreurId);
                livreurDto = livreur != null ? new LivreurDto
                {
                    Nom = livreur.Nom,
                    Prenom = livreur.Prenom,
                } : null;
            }
            var response = new AgenceDto
            {
                Id = agence.Id,
                Nom = agence.Nom,
                Telephone = agence.Telephone,
                Adresse = agence.Adresse,
                Email = agence.Email,
                VilleId = agence.VilleId,
                LivreurId = agence.LivreurId,
                Ville = villeDto,
                Livreur = livreurDto,
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAgence([FromRoute] Guid id)
        {
            var agence = await agenceRepo.DeleteAsync(id);
            if (agence == null) return NotFound();
            var response = new AgenceDto
            {
                Id = agence.Id,
                Nom = agence.Nom,
                Adresse = agence.Adresse,
            };
            return Ok(response);
        }
    }
}
