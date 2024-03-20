namespace GestioColis.Dto.Colis
{
    public class ColisDto
    {
        public Guid Id { get; set; }
        public float ValeurDeclarais { get; set; }
        public Boolean Fragile { get; set; }
        public float Poids { get; set; }
        public Boolean AutorisationOuverture { get; set; }
    }
}
