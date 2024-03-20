using GestioColis.Dto.Pays;
using GestioColis.Dto.Ville;

namespace GestioColis.Dto.Secteur
{
    public class SecteurDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int VilleId { get; set; }
        public VilleDto Ville { get; set; }
    }
}
