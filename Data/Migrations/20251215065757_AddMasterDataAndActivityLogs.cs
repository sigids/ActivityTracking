using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActivityTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterDataAndActivityLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bagian",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Jabatan",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KomputerType",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nama",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipeKaryawan",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MasterActivities",
                columns: table => new
                {
                    AktivitasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaAktivitas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterActivities", x => x.AktivitasID);
                });

            migrationBuilder.CreateTable(
                name: "MasterApplications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaAplikasi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterApplications", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "MasterFrequencies",
                columns: table => new
                {
                    FrequencyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaFrekuensi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFrequencies", x => x.FrequencyID);
                });

            migrationBuilder.CreateTable(
                name: "MasterWorkMethods",
                columns: table => new
                {
                    MethodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaMetode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterWorkMethods", x => x.MethodID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tanggal = table.Column<DateOnly>(type: "date", nullable: false),
                    ComputerNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AktivitasID = table.Column<int>(type: "int", nullable: true),
                    Deskripsi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DigunakanOleh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WaktuMulai = table.Column<TimeOnly>(type: "time", nullable: true),
                    WaktuSelesai = table.Column<TimeOnly>(type: "time", nullable: true),
                    DurasiMenit = table.Column<int>(type: "int", nullable: false),
                    FrekuensiID = table.Column<int>(type: "int", nullable: true),
                    MetodeKerjaID = table.Column<int>(type: "int", nullable: true),
                    AplikasiID = table.Column<int>(type: "int", nullable: true),
                    JenisDok = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NamaDok = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AsalDok = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_MasterActivities_AktivitasID",
                        column: x => x.AktivitasID,
                        principalTable: "MasterActivities",
                        principalColumn: "AktivitasID");
                    table.ForeignKey(
                        name: "FK_ActivityLogs_MasterApplications_AplikasiID",
                        column: x => x.AplikasiID,
                        principalTable: "MasterApplications",
                        principalColumn: "ApplicationID");
                    table.ForeignKey(
                        name: "FK_ActivityLogs_MasterFrequencies_FrekuensiID",
                        column: x => x.FrekuensiID,
                        principalTable: "MasterFrequencies",
                        principalColumn: "FrequencyID");
                    table.ForeignKey(
                        name: "FK_ActivityLogs_MasterWorkMethods_MetodeKerjaID",
                        column: x => x.MetodeKerjaID,
                        principalTable: "MasterWorkMethods",
                        principalColumn: "MethodID");
                });

            migrationBuilder.InsertData(
                table: "MasterActivities",
                columns: new[] { "AktivitasID", "IsActive", "NamaAktivitas" },
                values: new object[,]
                {
                    { 1, true, "Pemasukan Data" },
                    { 2, true, "Pencocokan Data" },
                    { 3, true, "Rekap Data" },
                    { 4, true, "Laporan Data" },
                    { 5, true, "Buat Data" }
                });

            migrationBuilder.InsertData(
                table: "MasterApplications",
                columns: new[] { "ApplicationID", "IsActive", "NamaAplikasi" },
                values: new object[,]
                {
                    { 1, true, "DTS" },
                    { 2, true, "Stage/Proman" },
                    { 3, true, "Entahr" },
                    { 4, true, "Lainnya" }
                });

            migrationBuilder.InsertData(
                table: "MasterFrequencies",
                columns: new[] { "FrequencyID", "IsActive", "NamaFrekuensi" },
                values: new object[,]
                {
                    { 1, true, "Per Jam" },
                    { 2, true, "Harian" },
                    { 3, true, "Mingguan" },
                    { 4, true, "Bulanan" },
                    { 5, true, "Insidentil" }
                });

            migrationBuilder.InsertData(
                table: "MasterWorkMethods",
                columns: new[] { "MethodID", "IsActive", "NamaMetode" },
                values: new object[,]
                {
                    { 1, true, "Tulis Tangan" },
                    { 2, true, "Non Sistem Aplikasi" },
                    { 3, true, "Email" },
                    { 4, true, "Sistem Aplikasi" },
                    { 5, true, "Print" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_AktivitasID",
                table: "ActivityLogs",
                column: "AktivitasID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_AplikasiID",
                table: "ActivityLogs",
                column: "AplikasiID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_FrekuensiID",
                table: "ActivityLogs",
                column: "FrekuensiID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_MetodeKerjaID",
                table: "ActivityLogs",
                column: "MetodeKerjaID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_UserID",
                table: "ActivityLogs",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "MasterActivities");

            migrationBuilder.DropTable(
                name: "MasterApplications");

            migrationBuilder.DropTable(
                name: "MasterFrequencies");

            migrationBuilder.DropTable(
                name: "MasterWorkMethods");

            migrationBuilder.DropColumn(
                name: "Bagian",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Jabatan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KomputerType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nama",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipeKaryawan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "AspNetUsers");
        }
    }
}
