using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityTracking.Migrations
{
    /// <inheritdoc />
    public partial class metodekerjafieldcomputerize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Computerize",
                table: "MasterWorkMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "MasterWorkMethods",
                keyColumn: "MethodID",
                keyValue: 1,
                column: "Computerize",
                value: false);

            migrationBuilder.UpdateData(
                table: "MasterWorkMethods",
                keyColumn: "MethodID",
                keyValue: 2,
                column: "Computerize",
                value: true);

            migrationBuilder.UpdateData(
                table: "MasterWorkMethods",
                keyColumn: "MethodID",
                keyValue: 3,
                column: "Computerize",
                value: true);

            migrationBuilder.UpdateData(
                table: "MasterWorkMethods",
                keyColumn: "MethodID",
                keyValue: 4,
                column: "Computerize",
                value: true);

            migrationBuilder.UpdateData(
                table: "MasterWorkMethods",
                keyColumn: "MethodID",
                keyValue: 5,
                column: "Computerize",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Computerize",
                table: "MasterWorkMethods");
        }
    }
}
