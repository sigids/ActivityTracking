using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityTracking.Migrations
{
    /// <inheritdoc />
    public partial class addstaffjamker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffJamKerjas",
                columns: table => new
                {
                    JamKerjaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tanggal = table.Column<DateOnly>(type: "date", nullable: false),
                    JamKerja = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffJamKerjas", x => x.JamKerjaID);
                    table.ForeignKey(
                        name: "FK_StaffJamKerjas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffJamKerjas_UserId_Tanggal",
                table: "StaffJamKerjas",
                columns: new[] { "UserId", "Tanggal" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffJamKerjas");
        }
    }
}
