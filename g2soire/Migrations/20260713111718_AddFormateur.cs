using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace g2soire.Migrations
{
    /// <inheritdoc />
    public partial class AddFormateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormateurId",
                table: "Formations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Formateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specialite = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formateurs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Formations_FormateurId",
                table: "Formations",
                column: "FormateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Formateurs_FormateurId",
                table: "Formations",
                column: "FormateurId",
                principalTable: "Formateurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Formateurs_FormateurId",
                table: "Formations");

            migrationBuilder.DropTable(
                name: "Formateurs");

            migrationBuilder.DropIndex(
                name: "IX_Formations_FormateurId",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "FormateurId",
                table: "Formations");
        }
    }
}
