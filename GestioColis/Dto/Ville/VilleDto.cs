using GestioColis.Dto.Pays;

namespace GestioColis.Dto.Ville
{
    public class VilleDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = "";
        public int PaysId { get; set; }
        public PaysDto? pays { get; set; }  
    }
}
