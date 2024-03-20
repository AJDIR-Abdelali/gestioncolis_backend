using System.ComponentModel.DataAnnotations;

namespace GestioColis.Dto.Client
{
    public class ClientDto
    {
       
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Prenom { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string Adresse { get; set; } = "";
    }
}
