using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActivityTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterJenisDok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterJenisDoks",
                columns: table => new
                {
                    JenisDokID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaJenisDok = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterJenisDoks", x => x.JenisDokID);
                });

            migrationBuilder.InsertData(
                table: "MasterJenisDoks",
                columns: new[] { "JenisDokID", "IsActive", "NamaJenisDok" },
                values: new object[,]
                {
                    { 1, true, "Excel" },
                    { 2, true, "PDF" },
                    { 3, true, "Word" },
                    { 4, true, "Gambar" },
                    { 5, true, "Print Out" },
                    { 6, true, "Tulisan Tangan" },
                    { 7, true, "Lainnya" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterJenisDoks");
        }
    }
}
