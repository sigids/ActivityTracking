using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActivityTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterComputerAndPengguna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterComputers",
                columns: table => new
                {
                    ComputerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaComputer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterComputers", x => x.ComputerID);
                });

            migrationBuilder.CreateTable(
                name: "MasterPenggunas",
                columns: table => new
                {
                    PenggunaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPengguna = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPenggunas", x => x.PenggunaID);
                });

            migrationBuilder.InsertData(
                table: "MasterComputers",
                columns: new[] { "ComputerID", "IsActive", "NamaComputer" },
                values: new object[,]
                {
                    { 1, true, "PC-001" },
                    { 2, true, "PC-002" },
                    { 3, true, "PC-003" },
                    { 4, true, "Laptop-001" },
                    { 5, true, "Laptop-002" }
                });

            migrationBuilder.InsertData(
                table: "MasterPenggunas",
                columns: new[] { "PenggunaID", "IsActive", "NamaPengguna" },
                values: new object[,]
                {
                    { 1, true, "Internal" },
                    { 2, true, "Eksternal" },
                    { 3, true, "Pribadi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterComputers");

            migrationBuilder.DropTable(
                name: "MasterPenggunas");
        }
    }
}
