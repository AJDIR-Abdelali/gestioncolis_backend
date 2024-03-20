using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class Produit
    {
        [Key]
        public Guid Id { get; set; } 

        public string Nom { get; set; } = "";

        public string Description { get; set; } = "";

        public float Prix { get; set; }

        public float Poids { get; set; }

    }
}
