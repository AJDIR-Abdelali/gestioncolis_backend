﻿// <auto-generated />
using System;
using GestioColis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestioColis.Migrations
{
    [DbContext(typeof(GestionColisContext))]
    partial class GestionColisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestioColis.Models.Agence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LivreurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VilleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivreurId");

                    b.HasIndex("VilleId");

                    b.ToTable("Agences");
                });

            modelBuilder.Entity("GestioColis.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("GestioColis.Models.Colis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AutorisationOuverture")
                        .HasColumnType("bit");

                    b.Property<Guid>("CommandeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Fragile")
                        .HasColumnType("bit");

                    b.Property<float>("Poids")
                        .HasColumnType("real");

                    b.Property<float>("ValeurDeclarais")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CommandeId");

                    b.ToTable("Colis");
                });

            modelBuilder.Entity("GestioColis.Models.ColisProduit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProduitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ColisId");

                    b.HasIndex("ProduitId");

                    b.ToTable("colisProduits");
                });

            modelBuilder.Entity("GestioColis.Models.Commande", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AgenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateChargement")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRetour")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LivreurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("StatutId")
                        .HasColumnType("int");

                    b.Property<float>("montant_total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AgenceId");

                    b.HasIndex("ClientId");

                    b.HasIndex("LivreurId");

                    b.HasIndex("StatutId");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("GestioColis.Models.Livreur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Livreurs");
                });

            modelBuilder.Entity("GestioColis.Models.Pays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("GestioColis.Models.Produit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Poids")
                        .HasColumnType("real");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("GestioColis.Models.Secteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("VilleId")
                        .HasColumnType("int");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VilleId");

                    b.ToTable("Secteurs");
                });

            modelBuilder.Entity("GestioColis.Models.Statut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuts");
                });

            modelBuilder.Entity("GestioColis.Models.Suivie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CommandeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VilleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommandeId");

                    b.HasIndex("VilleId");

                    b.ToTable("Suivies");
                });

            modelBuilder.Entity("GestioColis.Models.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaysId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaysId");

                    b.ToTable("Villes");
                });

            modelBuilder.Entity("GestioColis.Models.Agence", b =>
                {
                    b.HasOne("GestioColis.Models.Livreur", "Livreur")
                        .WithMany()
                        .HasForeignKey("LivreurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestioColis.Models.Ville", "Ville")
                        .WithMany()
                        .HasForeignKey("VilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livreur");

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("GestioColis.Models.Colis", b =>
                {
                    b.HasOne("GestioColis.Models.Commande", "Commande")
                        .WithMany()
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commande");
                });

            modelBuilder.Entity("GestioColis.Models.ColisProduit", b =>
                {
                    b.HasOne("GestioColis.Models.Colis", "Colis")
                        .WithMany()
                        .HasForeignKey("ColisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestioColis.Models.Produit", "Produit")
                        .WithMany()
                        .HasForeignKey("ProduitId");

                    b.Navigation("Colis");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("GestioColis.Models.Commande", b =>
                {
                    b.HasOne("GestioColis.Models.Agence", "Agence")
                        .WithMany()
                        .HasForeignKey("AgenceId");

                    b.HasOne("GestioColis.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("GestioColis.Models.Livreur", "Livreur")
                        .WithMany()
                        .HasForeignKey("LivreurId");

                    b.HasOne("GestioColis.Models.Statut", "Statut")
                        .WithMany()
                        .HasForeignKey("StatutId");

                    b.Navigation("Agence");

                    b.Navigation("Client");

                    b.Navigation("Livreur");

                    b.Navigation("Statut");
                });

            modelBuilder.Entity("GestioColis.Models.Secteur", b =>
                {
                    b.HasOne("GestioColis.Models.Ville", "Ville")
                        .WithMany()
                        .HasForeignKey("VilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("GestioColis.Models.Suivie", b =>
                {
                    b.HasOne("GestioColis.Models.Commande", "Commande")
                        .WithMany()
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestioColis.Models.Ville", "Ville")
                        .WithMany()
                        .HasForeignKey("VilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commande");

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("GestioColis.Models.Ville", b =>
                {
                    b.HasOne("GestioColis.Models.Pays", "Pays")
                        .WithMany()
                        .HasForeignKey("PaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pays");
                });
#pragma warning restore 612, 618
        }
    }
}
