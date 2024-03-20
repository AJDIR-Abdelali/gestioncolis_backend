using GestioColis.Dto.Livreur;
using GestioColis.Dto.Ville;
using GestioColis.Models;

namespace GestioColis.Dto.Agence
{
    public class AgenceDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Adresse { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string Email { get; set; } = "";
        public int VilleId { get; set; }
        public VilleDto? Ville { get; set; }
        public Guid LivreurId { get; set; }
        public LivreurDto? Livreur { get; set; }


    }
}
