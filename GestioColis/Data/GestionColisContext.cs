using GestioColis.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioColis.Data
{
    public class GestionColisContext :DbContext
    {
        public GestionColisContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Agence> Agences { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Colis> Colis { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
        public DbSet<Pays> Pays { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Secteur> Secteurs { get; set; }
        public DbSet<Statut> Statuts { get; set; }
        public DbSet<Suivie> Suivies { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<ColisProduit> colisProduits { get; set; }
    }
}
