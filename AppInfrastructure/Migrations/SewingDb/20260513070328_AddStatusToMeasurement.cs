using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppInfrastructure.Migrations.SewingDb
{
    /// <inheritdoc />
    public partial class AddStatusToMeasurement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Measurements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Measurements");
        }
    }
}
