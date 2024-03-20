using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioColis.Migrations
{
    /// <inheritdoc />
    public partial class First_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livreurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livreurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    Poids = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villes_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false),
                    LivreurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agences_Livreurs_LivreurId",
                        column: x => x.LivreurId,
                        principalTable: "Livreurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agences_Villes_VilleId",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Secteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secteurs_Villes_VilleId",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    montant_total = table.Column<float>(type: "real", nullable: false),
                    DateRetour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateChargement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AgenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LivreurId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Agences_AgenceId",
                        column: x => x.AgenceId,
                        principalTable: "Agences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commandes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commandes_Livreurs_LivreurId",
                        column: x => x.LivreurId,
                        principalTable: "Livreurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commandes_Statuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "Statuts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Colis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValeurDeclarais = table.Column<float>(type: "real", nullable: false),
                    Fragile = table.Column<bool>(type: "bit", nullable: false),
                    Poids = table.Column<float>(type: "real", nullable: false),
                    AutorisationOuverture = table.Column<bool>(type: "bit", nullable: false),
                    CommandeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colis_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suivies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suivies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suivies_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suivies_Villes_VilleId",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "colisProduits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProduitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ColisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colisProduits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_colisProduits_Colis_ColisId",
                        column: x => x.ColisId,
                        principalTable: "Colis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_colisProduits_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agences_LivreurId",
                table: "Agences",
                column: "LivreurId");

            migrationBuilder.CreateIndex(
                name: "IX_Agences_VilleId",
                table: "Agences",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_Colis_CommandeId",
                table: "Colis",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_colisProduits_ColisId",
                table: "colisProduits",
                column: "ColisId");

            migrationBuilder.CreateIndex(
                name: "IX_colisProduits_ProduitId",
                table: "colisProduits",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_AgenceId",
                table: "Commandes",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientId",
                table: "Commandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_LivreurId",
                table: "Commandes",
                column: "LivreurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_StatutId",
                table: "Commandes",
                column: "StatutId");

            migrationBuilder.CreateIndex(
                name: "IX_Secteurs_VilleId",
                table: "Secteurs",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_Suivies_CommandeId",
                table: "Suivies",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suivies_VilleId",
                table: "Suivies",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_Villes_PaysId",
                table: "Villes",
                column: "PaysId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "colisProduits");

            migrationBuilder.DropTable(
                name: "Secteurs");

            migrationBuilder.DropTable(
                name: "Suivies");

            migrationBuilder.DropTable(
                name: "Colis");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Agences");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Statuts");

            migrationBuilder.DropTable(
                name: "Livreurs");

            migrationBuilder.DropTable(
                name: "Villes");

            migrationBuilder.DropTable(
                name: "Pays");
        }
    }
}
