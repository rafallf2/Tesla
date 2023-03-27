using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesla.Data.Migrations
{
    /// <inheritdoc />
    public partial class Simplify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "CarLocalisations");

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "Availability",
                table: "CarLocalisations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
