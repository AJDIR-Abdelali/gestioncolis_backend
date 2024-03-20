namespace GestioColis.Dto.Produit
{
    public class ProduitDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Description { get; set; } = "";
        public float Prix { get; set; }
        public float Poids { get; set; }
    }
}
