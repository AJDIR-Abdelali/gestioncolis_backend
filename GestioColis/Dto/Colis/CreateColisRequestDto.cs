namespace GestioColis.Dto.Colis
{
    public class CreateColisRequestDto
    {
        public Guid Id { get; set; }
        public float ValeurDeclarais { get; set; }
        public Boolean Fragile { get; set; }
        public float Poids { get; set; }
        public Boolean AutorisationOuverture { get; set; }
        public Guid Commande { get; set; } // FK [Commande]
        public Guid Produit { get; set; }
        public List<Guid> Produits { get; set; } = new List<Guid>();
    }
}
