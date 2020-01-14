using Microsoft.EntityFrameworkCore.Migrations;

namespace planner.Migrations
{
    public partial class fixIdVisiteur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenement_Visisteur_VisisteurId",
                table: "Evenement");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Visisteur",
                newName: "IdVisiteur");

            migrationBuilder.RenameColumn(
                name: "VisisteurId",
                table: "Evenement",
                newName: "VisisteurIdVisiteur");

            migrationBuilder.RenameIndex(
                name: "IX_Evenement_VisisteurId",
                table: "Evenement",
                newName: "IX_Evenement_VisisteurIdVisiteur");

            migrationBuilder.AddForeignKey(
                name: "FK_Evenement_Visisteur_VisisteurIdVisiteur",
                table: "Evenement",
                column: "VisisteurIdVisiteur",
                principalTable: "Visisteur",
                principalColumn: "IdVisiteur",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenement_Visisteur_VisisteurIdVisiteur",
                table: "Evenement");

            migrationBuilder.RenameColumn(
                name: "IdVisiteur",
                table: "Visisteur",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VisisteurIdVisiteur",
                table: "Evenement",
                newName: "VisisteurId");

            migrationBuilder.RenameIndex(
                name: "IX_Evenement_VisisteurIdVisiteur",
                table: "Evenement",
                newName: "IX_Evenement_VisisteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evenement_Visisteur_VisisteurId",
                table: "Evenement",
                column: "VisisteurId",
                principalTable: "Visisteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
