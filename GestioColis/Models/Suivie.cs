using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class Suivie
    {
        [Key]
        public int Id { get; set; }

        public Guid CommandeId { get; set; }
        public Commande? Commande { get; set; }

        public int VilleId { get; set; }
        public Ville? Ville { get; set; }
    }
}
