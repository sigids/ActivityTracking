using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActivityTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterJabatanBagianUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterBagians",
                columns: table => new
                {
                    BagianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaBagian = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterBagians", x => x.BagianID);
                });

            migrationBuilder.CreateTable(
                name: "MasterJabatans",
                columns: table => new
                {
                    JabatanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaJabatan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterJabatans", x => x.JabatanID);
                });

            migrationBuilder.CreateTable(
                name: "MasterUnits",
                columns: table => new
                {
                    UnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterUnits", x => x.UnitID);
                });

            migrationBuilder.InsertData(
                table: "MasterBagians",
                columns: new[] { "BagianID", "IsActive", "NamaBagian" },
                values: new object[,]
                {
                    { 1, true, "Produksi" },
                    { 2, true, "QC" },
                    { 3, true, "Warehouse" }
                });

            migrationBuilder.InsertData(
                table: "MasterJabatans",
                columns: new[] { "JabatanID", "IsActive", "NamaJabatan" },
                values: new object[,]
                {
                    { 1, true, "Staff Admin" },
                    { 2, true, "Supervisor" },
                    { 3, true, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "MasterUnits",
                columns: new[] { "UnitID", "IsActive", "NamaUnit" },
                values: new object[,]
                {
                    { 1, true, "Unit A" },
                    { 2, true, "Unit B" },
                    { 3, true, "Unit C" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterBagians");

            migrationBuilder.DropTable(
                name: "MasterJabatans");

            migrationBuilder.DropTable(
                name: "MasterUnits");
        }
    }
}
