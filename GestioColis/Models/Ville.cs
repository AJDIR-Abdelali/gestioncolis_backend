using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class Ville
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; } = "";
        public int PaysId { get; set; } 
        public Pays? Pays { get; set; }  
    }
}
