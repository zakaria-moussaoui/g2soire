using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace g2soire.Migrations
{
    /// <inheritdoc />
    public partial class FormationLiens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Formations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Formations_CategorieId",
                table: "Formations",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Categories_CategorieId",
                table: "Formations",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Categories_CategorieId",
                table: "Formations");

            migrationBuilder.DropIndex(
                name: "IX_Formations_CategorieId",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Formations");
        }
    }
}
