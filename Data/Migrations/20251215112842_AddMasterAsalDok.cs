using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActivityTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterAsalDok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterAsalDoks",
                columns: table => new
                {
                    AsalDokID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaAsalDok = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAsalDoks", x => x.AsalDokID);
                });

            migrationBuilder.InsertData(
                table: "MasterAsalDoks",
                columns: new[] { "AsalDokID", "IsActive", "NamaAsalDok" },
                values: new object[,]
                {
                    { 1, true, "Cutting" },
                    { 2, true, "IE" },
                    { 3, true, "Sewing Line" },
                    { 4, true, "HRD" },
                    { 5, true, "Packing" },
                    { 6, true, "Lainnya" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterAsalDoks");
        }
    }
}
