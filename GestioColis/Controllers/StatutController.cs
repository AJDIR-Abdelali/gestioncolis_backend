using GestioColis.Dto.Secteur;
using GestioColis.Dto.Statuts;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatutController : ControllerBase
    {
        private readonly IStatutRepo statutRepo;

        public StatutController(IStatutRepo statutRepo)
        {
            this.statutRepo = statutRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatut([FromBody] CreateStatutRequestDto request)
        {
            var statut = new Statut
            {
                Nom = request.Nom,
            };

            await statutRepo.StatutAsync(statut);

            var response = new StatutDto
            {
                Id = statut.Id,
                Nom = statut.Nom,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            var statuts = await statutRepo.GetAllStatutsAsync();
            var response = new List<StatutDto>();

            foreach (var statut in statuts)
            {
                response.Add(new StatutDto { Id = statut.Id, Nom = statut.Nom });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetStatutById([FromRoute] int id)
        {
            var statut = await statutRepo.GetById(id);

            if (statut == null) return NotFound();

            var response = new StatutDto { Id = statut.Id, Nom = statut.Nom };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateStatut([FromRoute] int id, UpdateStatuRequestDto request)
        {
            var statut = new Statut
            {
                Id = id,
                Nom = request.Nom,
            };
            statut = await statutRepo.UpdateAsync(statut);
            if (statut == null) return NotFound();
            var response = new StatutDto { Id = statut.Id, Nom = statut.Nom };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStatut([FromRoute] int id)
        {
            var existingStatut = await statutRepo.DeleteAsync(id);
            if (existingStatut == null) return NotFound();
            var response = new StatutDto
            {
                Id = existingStatut.Id,
                Nom = existingStatut.Nom,
            };
            return Ok(response);
        }
    }
}
