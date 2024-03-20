using GestioColis.Dto.Client;
using GestioColis.Dto.Livreur;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreurController : ControllerBase
    {
        private readonly ILivreurRepo livreurRepo;

        public LivreurController(ILivreurRepo livreurRepo)
        {
            this.livreurRepo = livreurRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateLivreurRequestDto request)
        {
            var livreur = new Livreur
            {
                Nom = request.Nom,
                Prenom = request.Prenom,
                Telephone = request.Telephone,
                Email = request.Email,
            };
            await livreurRepo.LivreurAsync(livreur);

            var response = new LivreurDto
            {
                Id = livreur.Id,
                Nom = livreur.Nom,
                Prenom = livreur.Prenom,
                Telephone = livreur.Telephone,
                Email = livreur.Email,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduis()
        {
            var livreurs = await livreurRepo.GetAllLivreursAsync();

            var response = new List<LivreurDto>();

            foreach (var livreur in livreurs)
            {
                response.Add(new LivreurDto
                {
                    Id= livreur.Id,
                    Nom = livreur.Nom,
                    Prenom = livreur.Prenom,
                    Telephone = livreur.Telephone,
                    Email = livreur.Email,
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetLivreurById([FromRoute] Guid id)
        {
            var existingLivreur = await livreurRepo.GetById(id);

            if (existingLivreur == null)
                return NotFound();

            var response = new LivreurDto
            {
                Id = existingLivreur.Id,
                Nom = existingLivreur.Nom,
                Prenom = existingLivreur.Prenom,
                Email = existingLivreur.Email,
                Telephone = existingLivreur.Telephone,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateLivreur([FromRoute] Guid id , UpdateLivreurRequestDto request)
        {
            var livreur = new Livreur {
                Id = id,
                Nom= request.Nom,
                Prenom  = request.Prenom,
                Email = request.Email,
                Telephone = request.Telephone,
            };

            livreur = await livreurRepo.UpdateAsync(livreur);

            if (livreur == null)
                return NotFound();

            var response = new LivreurDto
            {
                Id = livreur.Id,
                Nom = livreur.Nom,
                Prenom= livreur.Prenom,
                Email = livreur.Email,
                Telephone= livreur.Telephone,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteLivreur([FromRoute] Guid id)
        {
            var livreur =  await livreurRepo.DeleteWithMessageAsync(id);

            if(livreur == null) return NotFound();

            var response = new LivreurDto
            {
                Id = livreur.Livreur.Id,
                Nom = livreur.Livreur.Nom,
                Prenom = livreur.Livreur.Prenom,
                Telephone = livreur.Livreur.Telephone,
                Email = livreur.Livreur.Email,
            };
            return Ok(livreur.Message);
        }



    }
}
