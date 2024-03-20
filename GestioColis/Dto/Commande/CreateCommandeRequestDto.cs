using GestioColis.Dto.Agence;
using GestioColis.Dto.Client;
using GestioColis.Dto.Livreur;
using GestioColis.Dto.Statuts;

namespace GestioColis.Dto.Commande
{
    public class CreateCommandeRequestDto
    {
        //public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public float montant_total { get; set; }
        public DateTime DateRetour { get; set; }
        public string Description { get; set; } = "";
        public DateTime DateChargement { get; set; }
        public Guid ClientId { get; set; }
        //public ClientDto? Client { get; set; }
        public Guid AgenceId { get; set; }
        //public AgenceDto? Agence { get; set; }
        public Guid LivreurId { get; set; } 
        //public LivreurDto? Livreur { get; set; }
        public int StatutId { get; set; }
        //public StatutDto? Statut { get; set; }
    }
}
