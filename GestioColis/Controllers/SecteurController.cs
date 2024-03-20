using GestioColis.Dto.Pays;
using GestioColis.Dto.Secteur;
using GestioColis.Dto.Ville;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecteurController : ControllerBase
    {
        private readonly ISecteurRepo secteurRepo;
        private readonly IVilleRepo villeRepo;
        private readonly IPaysRepo paysRepo;

        public SecteurController(
            ISecteurRepo secteurRepo, 
            IVilleRepo villeRepo , 
            IPaysRepo paysRepo)
        {
            this.secteurRepo = secteurRepo;
            this.villeRepo = villeRepo;
            this.paysRepo = paysRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVille([FromBody] CreateSecteurRequestDto request)
        {
            var secteur = new Secteur
            {
                nom = request.Nom.ToUpper(),
                VilleId = request.VilleId,
            };

            var response = new SecteurDto
            {
                Nom = request.Nom,
                VilleId = request.VilleId,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSecteurs()
        {
            var secteurs = await secteurRepo.GetAllSecteursAsync();
            var response = new List<SecteurDto>();
            foreach (var secteur in secteurs)
            {
                if (secteur.VilleId != null)
                {
                    var ville = await villeRepo.GetById(secteur.VilleId);
                    var pays = await paysRepo.GetById(secteur.Ville.PaysId);

                    var paysDto = pays != null ? new PaysDto
                    {
                        Id = pays.Id,
                        Nom = pays.Nom,
                        
                    } : null;

                    var villeDto = ville != null ? new VilleDto
                    {
                        Id = ville.Id,
                        Nom = ville.Nom,
                        PaysId = paysDto.Id,
                        pays = paysDto,
                        
                    } : null;

                    response.Add(new SecteurDto
                    {
                        Id = secteur.Id,
                        Nom = secteur.nom,
                        VilleId = secteur.VilleId,
                        Ville = villeDto,
                    });
                }
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBySecteurId([FromRoute] int id)
        {
            var existingSecteur = await secteurRepo.GetById(id);

            if (existingSecteur == null) return NotFound();

            VilleDto? villeDto = null;

            if (existingSecteur.VilleId != null)
            {

                var ville = await villeRepo.GetById(existingSecteur.VilleId);
                var pays = await paysRepo.GetById(existingSecteur.Ville.PaysId);

                var paysDto = pays != null ? new PaysDto
                {
                    Id = pays.Id,
                    Nom = pays.Nom,


                } : null;

                villeDto = ville != null ? new VilleDto
                {
                    Id = ville.Id,
                    Nom = ville.Nom,
                    PaysId = paysDto.Id,
                    pays = paysDto,

                } : null;
            }
            var response = new SecteurDto
            {
                Id = existingSecteur.Id,
                Nom = existingSecteur.nom,
                VilleId = existingSecteur.VilleId,
                Ville = villeDto
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateSecteur([FromRoute] int id, UpdateSecteurRequestDto request)
        {
            var secteur = new Secteur
            {
                Id = id,
                nom = request.Nom,
                VilleId = request.VilleId,
            };

            secteur = await secteurRepo.UpdateAsync(secteur);

            if (secteur == null) return NotFound();

            VilleDto? villeDto = null;

            if (secteur.VilleId != null)
            {

                var ville = await villeRepo.GetById(secteur.VilleId);


                villeDto = ville != null ? new VilleDto
                {
                    Id = ville.Id,
                    Nom = ville.Nom,
                } : null;
            }

            var response = new SecteurDto
            {
                Id = secteur.Id,
                Nom = secteur.nom,
                VilleId = secteur.VilleId,
            };

            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteSecteur([FromRoute] int id)
        {
            var secteur = await secteurRepo.DeleteAsync(id);
            if(secteur == null) return NotFound();
            var response = new SecteurDto
            {
                Id = secteur.Id,
                Nom = secteur.nom,
                VilleId = secteur.VilleId,
            };
            return Ok(response);
        }

    }
}