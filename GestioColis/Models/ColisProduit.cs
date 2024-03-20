using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class ColisProduit
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? ProduitId { get; set; }
        public Produit? Produit { get; set; }

        public Guid ColisId { get; set; }
        public Colis? Colis { get; set; }
    }
}
