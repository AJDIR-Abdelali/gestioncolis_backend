namespace GestioColis.Dto.Secteur
{
    public class UpdateSecteurRequestDto
    {
        //public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int VilleId { get; set; }
    }
}
