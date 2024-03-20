using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class Commande
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; } 

        public float montant_total { get; set; }

        public DateTime DateRetour { get; set; }

        public string Description { get; set; } = "";

        public DateTime DateChargement { get; set; }

        public Guid ClientId { get; set; }
        public Client? Client { get; set; }
        
        public Guid AgenceId { get; set; }
        public Agence? Agence { get; set; }
        
        public Guid LivreurId { get; set; }
        public Livreur? Livreur { get; set; }

        public int StatutId { get; set; }
        public Statut? Statut { get; set; }
    }
}
