namespace GestioColis.Dto.Agence
{
    public class UpdateAgenceRequestDto
    {
        //public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Adresse { get; set; } = "";
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = "";
        public int VilleId { get; set; }
        public Guid LivreurId { get; set; }
    }
}
