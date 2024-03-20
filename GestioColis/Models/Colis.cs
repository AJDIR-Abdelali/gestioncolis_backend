using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace GestioColis.Models
{
    public class Colis
    {
        [Key]
        public Guid Id { get; set; }

        public float ValeurDeclarais { get; set; }

        public Boolean Fragile { get; set; }

        public float Poids { get; set; }

        public Boolean AutorisationOuverture { get; set; }

        public Guid CommandeId { get; set; }
        public Commande? Commande { get; set; } 
    }
}
