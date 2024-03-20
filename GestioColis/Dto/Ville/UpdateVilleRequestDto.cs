using GestioColis.Dto.Pays;

namespace GestioColis.Dto.Ville
{
    public class UpdateVilleRequestDto
    {
        //public int Id { get; set; }
        public string Nom { get; set; } = "";
        public int PaysId { get; set; }
        //public PaysDto? pays { get; set; }
    }
}
