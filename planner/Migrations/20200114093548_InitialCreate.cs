using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace planner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisateur",
                columns: table => new
                {
                    Login = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Port = table.Column<string>(nullable: true),
                    DateInscription = table.Column<DateTime>(nullable: false),
                    IdOrga = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomOrganisation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisateur", x => x.IdOrga);
                });

            migrationBuilder.CreateTable(
                name: "Visisteur",
                columns: table => new
                {
                    Login = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Port = table.Column<string>(nullable: true),
                    DateInscription = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visisteur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evenement",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganisateurIdOrga = table.Column<int>(nullable: true),
                    Titre = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateHeureCreation = table.Column<DateTime>(nullable: false),
                    DateHeureEvenement = table.Column<DateTime>(nullable: false),
                    Ville = table.Column<string>(nullable: true),
                    Cp = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    VisisteurId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenement", x => x.IdEvent);
                    table.ForeignKey(
                        name: "FK_Evenement_Organisateur_OrganisateurIdOrga",
                        column: x => x.OrganisateurIdOrga,
                        principalTable: "Organisateur",
                        principalColumn: "IdOrga",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evenement_Visisteur_VisisteurId",
                        column: x => x.VisisteurId,
                        principalTable: "Visisteur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_OrganisateurIdOrga",
                table: "Evenement",
                column: "OrganisateurIdOrga");

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_VisisteurId",
                table: "Evenement",
                column: "VisisteurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evenement");

            migrationBuilder.DropTable(
                name: "Organisateur");

            migrationBuilder.DropTable(
                name: "Visisteur");
        }
    }
}
