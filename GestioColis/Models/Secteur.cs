using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class Secteur
    {
        [Key]
        public int Id { get; set; }

        public string nom { get; set; } = string.Empty;

        public int VilleId { get; set; }
        public Ville? Ville  { get; set; } // FK  [Ville]

     
        
    }
}
