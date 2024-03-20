namespace GestioColis.Dto.Client
{
    public class CreateClientRequestDto
    {
        public string Nom { get; set; } = "";
        public string Prenom { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string Adresse { get; set; } = "";
    }
}
