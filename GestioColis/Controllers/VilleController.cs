using GestioColis.Dto.Pays;
using GestioColis.Dto.Ville;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VilleController : ControllerBase
    {
        private readonly IVilleRepo villeRepo;
        private readonly IPaysRepo paysRepo;

        public VilleController(IVilleRepo villeRepo, IPaysRepo paysRepo)
        {
            this.villeRepo = villeRepo;
            this.paysRepo = paysRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVille([FromBody] CreateVilleRequestDto request)
        {
            var ville = new Ville
            {
                Nom = request.Nom.ToUpper(),
                PaysId = request.PaysId,
            };

            await villeRepo.VilleAsync(ville);

            var response = new VilleDto
            {
                Nom = ville.Nom,
                PaysId = ville.PaysId,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVille()
        {
            var villes = await villeRepo.GetAllVillesAsync();
            var response = new List<VilleDto>();
            foreach (var ville in villes)
            {
                if (ville.PaysId != null)
                {
                    var pays = await paysRepo.GetById(ville.PaysId);
                    var paysDto = pays != null ? new PaysDto
                    {
                        Id = pays.Id,
                        Nom = pays.Nom
                    } : null;
                    response.Add(new VilleDto
                    {
                        Id = ville.Id,
                        Nom = ville.Nom,
                        PaysId = ville.PaysId,
                        pays = paysDto // Assign the paysDto
                    });
                }
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetVilleById([FromRoute] int id)
        {
            var existingVille = await villeRepo.GetById(id);

            if (existingVille == null)
                return NotFound();

            PaysDto? paysDto = null; // Declare paysDto outside the if block

            if (existingVille.PaysId != null)
            {
                var pays = await paysRepo.GetById(existingVille.PaysId);
                paysDto = pays != null ? new PaysDto
                {
                    Id = pays.Id,
                    Nom = pays.Nom
                } : null;
            }
            var response = new VilleDto
            {
                Id = existingVille.Id,
                Nom = existingVille.Nom,
                PaysId = existingVille.PaysId,
                pays = paysDto // Assign the paysDto
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateVille([FromRoute] int id, UpdateVilleRequestDto request)
        {
            var ville = new Ville
            {
                Id = id,
                Nom = request.Nom.ToUpper(),
                PaysId = request.PaysId,
            };

            ville = await villeRepo.UpdateAsync(ville);

            if (ville == null) return NotFound();

            PaysDto? paysDto = null; // Declare paysDto outside the if block

            if (ville.PaysId != null)
            {
                var pays = await paysRepo.GetById(ville.PaysId);
                paysDto = pays != null ? new PaysDto
                {
                    Id = pays.Id,
                    Nom = pays.Nom
                } : null;
            }

            var response = new VilleDto
            {
                Id = ville.Id,
                Nom = ville.Nom,
                PaysId = ville.PaysId,
                pays = paysDto,
            };

            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteVille([FromRoute] int id)
        {
            var ville = await villeRepo.DeleteAsync(id);
            if (ville == null) return NotFound();
            var response = new VilleDto
            {
                Id = ville.Id,
                Nom = ville.Nom,
                PaysId = ville.Id
            };
            return Ok(response);
        }

    }
}
