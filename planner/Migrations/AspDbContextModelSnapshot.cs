﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using planner;

namespace planner.Migrations
{
    [DbContext(typeof(AspDbContext))]
    partial class AspDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("planner.Models.Evenement", b =>
                {
                    b.Property<int>("IdEvent")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse");

                    b.Property<string>("Cp");

                    b.Property<DateTime>("DateHeureCreation");

                    b.Property<DateTime>("DateHeureEvenement");

                    b.Property<string>("Description");

                    b.Property<int?>("OrganisateurIdOrga");

                    b.Property<string>("Tags");

                    b.Property<string>("Titre");

                    b.Property<string>("Ville");

                    b.Property<int?>("VisisteurIdVisiteur");

                    b.HasKey("IdEvent");

                    b.HasIndex("OrganisateurIdOrga");

                    b.HasIndex("VisisteurIdVisiteur");

                    b.ToTable("Evenement");
                });

            modelBuilder.Entity("planner.Models.Organisateur", b =>
                {
                    b.Property<int>("IdOrga")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInscription");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Nom");

                    b.Property<string>("NomOrganisation");

                    b.Property<string>("Port");

                    b.Property<string>("Prenom");

                    b.Property<string>("Tel");

                    b.HasKey("IdOrga");

                    b.ToTable("Organisateur");
                });

            modelBuilder.Entity("planner.Models.Visisteur", b =>
                {
                    b.Property<int>("IdVisiteur")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInscription");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Nom");

                    b.Property<string>("Port");

                    b.Property<string>("Prenom");

                    b.Property<string>("Tel");

                    b.HasKey("IdVisiteur");

                    b.ToTable("Visisteur");
                });

            modelBuilder.Entity("planner.Models.Evenement", b =>
                {
                    b.HasOne("planner.Models.Organisateur", "Organisateur")
                        .WithMany("EvenementsOrganises")
                        .HasForeignKey("OrganisateurIdOrga");

                    b.HasOne("planner.Models.Visisteur")
                        .WithMany("Evenements")
                        .HasForeignKey("VisisteurIdVisiteur");
                });
#pragma warning restore 612, 618
        }
    }
}
