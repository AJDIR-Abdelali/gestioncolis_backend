using System.ComponentModel.DataAnnotations;

namespace GestioColis.Models
{
    public class Pays
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; } = "";
    }
}
