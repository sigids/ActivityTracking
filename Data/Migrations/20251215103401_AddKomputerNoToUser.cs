using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddKomputerNoToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KomputerNo",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KomputerNo",
                table: "AspNetUsers");
        }
    }
}
