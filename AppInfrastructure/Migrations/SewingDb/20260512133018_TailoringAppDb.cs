using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppInfrastructure.Migrations.SewingDb
{
    /// <inheritdoc />
    public partial class TailoringAppDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shoulder = table.Column<double>(type: "float", nullable: false),
                    UpperBust = table.Column<double>(type: "float", nullable: false),
                    Bust = table.Column<double>(type: "float", nullable: false),
                    LowerBust = table.Column<double>(type: "float", nullable: false),
                    FrontFigure = table.Column<double>(type: "float", nullable: false),
                    BackFigure = table.Column<double>(type: "float", nullable: false),
                    FrontChest = table.Column<double>(type: "float", nullable: false),
                    BackChest = table.Column<double>(type: "float", nullable: false),
                    UpperHips = table.Column<double>(type: "float", nullable: false),
                    Waistline = table.Column<double>(type: "float", nullable: false),
                    NeckDip = table.Column<double>(type: "float", nullable: false),
                    ArmHole = table.Column<double>(type: "float", nullable: false),
                    ArmCircumference = table.Column<double>(type: "float", nullable: false),
                    SleeveLength = table.Column<double>(type: "float", nullable: false),
                    LowerHips = table.Column<double>(type: "float", nullable: false),
                    Crotch = table.Column<double>(type: "float", nullable: false),
                    CalfCircumference = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Thigh = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
