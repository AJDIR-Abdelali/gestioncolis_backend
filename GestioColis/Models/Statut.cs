using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class Statut
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; } = "";
    }
}
