using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesla.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCarLocalisation");

            migrationBuilder.DropTable(
                name: "CarLocalisationLocalisation");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "CarLocalisations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalisationId",
                table: "CarLocalisations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarLocalisations_CarId",
                table: "CarLocalisations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLocalisations_LocalisationId",
                table: "CarLocalisations",
                column: "LocalisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarLocalisations_Cars_CarId",
                table: "CarLocalisations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarLocalisations_Localisations_LocalisationId",
                table: "CarLocalisations",
                column: "LocalisationId",
                principalTable: "Localisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarLocalisations_Cars_CarId",
                table: "CarLocalisations");

            migrationBuilder.DropForeignKey(
                name: "FK_CarLocalisations_Localisations_LocalisationId",
                table: "CarLocalisations");

            migrationBuilder.DropIndex(
                name: "IX_CarLocalisations_CarId",
                table: "CarLocalisations");

            migrationBuilder.DropIndex(
                name: "IX_CarLocalisations_LocalisationId",
                table: "CarLocalisations");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarLocalisations");

            migrationBuilder.DropColumn(
                name: "LocalisationId",
                table: "CarLocalisations");

            migrationBuilder.CreateTable(
                name: "CarCarLocalisation",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CarLocalisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCarLocalisation", x => new { x.CarId, x.CarLocalisationId });
                    table.ForeignKey(
                        name: "FK_CarCarLocalisation_CarLocalisations_CarLocalisationId",
                        column: x => x.CarLocalisationId,
                        principalTable: "CarLocalisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCarLocalisation_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarLocalisationLocalisation",
                columns: table => new
                {
                    CarLocalisationId = table.Column<int>(type: "int", nullable: false),
                    LocalisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarLocalisationLocalisation", x => new { x.CarLocalisationId, x.LocalisationId });
                    table.ForeignKey(
                        name: "FK_CarLocalisationLocalisation_CarLocalisations_CarLocalisationId",
                        column: x => x.CarLocalisationId,
                        principalTable: "CarLocalisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarLocalisationLocalisation_Localisations_LocalisationId",
                        column: x => x.LocalisationId,
                        principalTable: "Localisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCarLocalisation_CarLocalisationId",
                table: "CarCarLocalisation",
                column: "CarLocalisationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLocalisationLocalisation_LocalisationId",
                table: "CarLocalisationLocalisation",
                column: "LocalisationId");
        }
    }
}
