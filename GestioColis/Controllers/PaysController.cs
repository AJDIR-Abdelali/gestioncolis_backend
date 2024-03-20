using GestioColis.Dto.Pays;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        private readonly IPaysRepo paysRepo;

        public PaysController(IPaysRepo paysRepo)
        {
            this.paysRepo = paysRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePays([FromBody] CreatePaysRequestDto request)
        {
            var pays = new Pays
            {
                Nom = request.Nom.ToUpper(),
            };
            await paysRepo.PaysAsync(pays);

            var response = new PaysDto
            {
                Id = pays.Id,
                Nom = pays.Nom,
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPays()
        {
            var List_Pays = await paysRepo.GetAllPaysAsync();

            var response = new List<PaysDto>();

            foreach (var pays in List_Pays)
            {
                response.Add(new PaysDto
                {
                    Id = pays.Id,
                    Nom = pays.Nom,
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPaysById([FromRoute] int id)
        {
            var existingPays = await paysRepo.GetById(id);

            if (existingPays == null)
                return NotFound();

            var response = new PaysDto { Id = existingPays.Id, Nom = existingPays.Nom };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePays([FromRoute] int id, UpdatePaysRequestDto request)
        {
            var pays = new Pays
            {
                Id = id,
                Nom = request.Nom.ToUpper(),
            };

            pays = await paysRepo.UpdateAsync(pays);

            if (pays == null) return NotFound();

            var response = new PaysDto
            {
                Id = pays.Id,
                Nom = pays.Nom,
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePays([FromRoute] int id)
        {
            var pays = await paysRepo.DeleteAsync(id);
            if (pays == null) return NotFound();
            var response = new PaysDto()
            {
                Id = pays.Id,
                Nom = pays.Nom,
            };
            return Ok(response);
        }
    }
}
