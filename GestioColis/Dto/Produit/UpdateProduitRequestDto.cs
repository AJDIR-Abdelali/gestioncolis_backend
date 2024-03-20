namespace GestioColis.Dto.Produit
{
    public class UpdateProduitRequestDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Description { get; set; } = "";
        public float Prix { get; set; }
        public float Poids { get; set; }
    }
}
