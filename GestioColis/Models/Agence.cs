using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class Agence
    {
        [Key]
        public Guid Id { get; set; }

        public string Nom { get; set; } = "";

        public string Adresse { get; set; } = "";

        public string Telephone { get; set; } = "";

        public string Email { get; set; } = "";

        public int VilleId { get; set; }
        public Ville?  Ville { get; set; }

        public Guid LivreurId { get; set; }
        public Livreur? Livreur { get; set; }
        
    }
}
