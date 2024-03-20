using GestioColis.Dto.Pays;

namespace GestioColis.Dto.Ville
{
    public class CreateVilleRequestDto
    {
        public string Nom { get; set; } = "";
        public int PaysId { get; set; }
    }
}
