using GestioColis.Dto.Client;
using GestioColis.Dto.Produit;
using GestioColis.Models;
using GestioColis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioColis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitRepo produitRepo;

        public ProduitController(IProduitRepo produitRepo)
        {
            this.produitRepo = produitRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduit([FromBody] CreateProduitRequestDto request)
        {
            var produit = new Produit
            {
                Nom = request.Nom,
                Description = request.Description,
                Prix = request.Prix,
                Poids = request.Poids,
            };

            await produitRepo.ProduitAsync(produit);

            var response = new ProduitDto
            {
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                Poids = produit.Poids,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var produirs = await produitRepo.GetAllProduitsAsync();

            var response = new List<ProduitDto>();

            foreach (var produit in produirs)
            {
                response.Add(new ProduitDto
                {
                    Id = produit.Id,
                    Nom = produit.Nom,
                    Description = produit.Description,
                    Poids = produit.Poids,
                    Prix = produit.Prix,
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProduitById([FromRoute] Guid id)
        {
            var existingProduit = await produitRepo.GetById(id);
            if (existingProduit == null)
                return NotFound();

            var response = new ProduitDto
            {
                Id = existingProduit.Id,
                Nom = existingProduit.Nom,
                Description = existingProduit.Description,
                Poids = existingProduit.Poids,
                Prix = existingProduit.Prix,
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditProduit([FromRoute] Guid id, UpdateProduitRequestDto request)
        {
            var produit = new Produit
            {
                Id = id,
                Nom = request.Nom,
                Description = request.Description,
                Prix = request.Prix,
                Poids = request.Poids,
            };
            produit = await produitRepo.UpdateAsync(produit);

            if (produit == null) return NotFound();

            var response = new ProduitDto
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Poids = produit.Poids,
                Prix = produit.Prix,
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProduit([FromRoute] Guid id)
        {
            var produit = await produitRepo.DeleteAsync(id);

            if (produit == null) return NotFound();

            var response = new ProduitDto
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Poids = produit.Poids,
                Prix = produit.Prix,
            };
            return Ok(response);
        }
    }
}
