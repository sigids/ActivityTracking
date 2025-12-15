using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracking.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<MasterActivity> MasterActivities { get; set; }
        public DbSet<MasterFrequency> MasterFrequencies { get; set; }
        public DbSet<MasterWorkMethod> MasterWorkMethods { get; set; }
        public DbSet<MasterApplication> MasterApplications { get; set; }
        public DbSet<MasterJabatan> MasterJabatans { get; set; }
        public DbSet<MasterBagian> MasterBagians { get; set; }
        public DbSet<MasterUnit> MasterUnits { get; set; }
        public DbSet<MasterComputer> MasterComputers { get; set; }
        public DbSet<MasterPengguna> MasterPenggunas { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<ActivityLogFile> ActivityLogFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed default master data
            builder.Entity<MasterActivity>().HasData(
                new MasterActivity { AktivitasID = 1, NamaAktivitas = "Pemasukan Data" },
                new MasterActivity { AktivitasID = 2, NamaAktivitas = "Pencocokan Data" },
                new MasterActivity { AktivitasID = 3, NamaAktivitas = "Rekap Data" },
                new MasterActivity { AktivitasID = 4, NamaAktivitas = "Laporan Data" },
                new MasterActivity { AktivitasID = 5, NamaAktivitas = "Buat Data" }
            );

            builder.Entity<MasterFrequency>().HasData(
                new MasterFrequency { FrequencyID = 1, NamaFrekuensi = "Per Jam" },
                new MasterFrequency { FrequencyID = 2, NamaFrekuensi = "Harian" },
                new MasterFrequency { FrequencyID = 3, NamaFrekuensi = "Mingguan" },
                new MasterFrequency { FrequencyID = 4, NamaFrekuensi = "Bulanan" },
                new MasterFrequency { FrequencyID = 5, NamaFrekuensi = "Insidentil" }
            );

            builder.Entity<MasterWorkMethod>().HasData(
                new MasterWorkMethod { MethodID = 1, NamaMetode = "Tulis Tangan" },
                new MasterWorkMethod { MethodID = 2, NamaMetode = "Non Sistem Aplikasi" },
                new MasterWorkMethod { MethodID = 3, NamaMetode = "Email" },
                new MasterWorkMethod { MethodID = 4, NamaMetode = "Sistem Aplikasi" },
                new MasterWorkMethod { MethodID = 5, NamaMetode = "Print" }
            );

            builder.Entity<MasterApplication>().HasData(
                new MasterApplication { ApplicationID = 1, NamaAplikasi = "DTS" },
                new MasterApplication { ApplicationID = 2, NamaAplikasi = "Stage/Proman" },
                new MasterApplication { ApplicationID = 3, NamaAplikasi = "Entahr" },
                new MasterApplication { ApplicationID = 4, NamaAplikasi = "Lainnya" }
            );

            builder.Entity<MasterJabatan>().HasData(
                new MasterJabatan { JabatanID = 1, NamaJabatan = "Staff Admin" },
                new MasterJabatan { JabatanID = 2, NamaJabatan = "Supervisor" },
                new MasterJabatan { JabatanID = 3, NamaJabatan = "Manager" }
            );

            builder.Entity<MasterBagian>().HasData(
                new MasterBagian { BagianID = 1, NamaBagian = "Produksi" },
                new MasterBagian { BagianID = 2, NamaBagian = "QC" },
                new MasterBagian { BagianID = 3, NamaBagian = "Warehouse" }
            );

            builder.Entity<MasterUnit>().HasData(
                new MasterUnit { UnitID = 1, NamaUnit = "Unit A" },
                new MasterUnit { UnitID = 2, NamaUnit = "Unit B" },
                new MasterUnit { UnitID = 3, NamaUnit = "Unit C" }
            );

            builder.Entity<MasterComputer>().HasData(
                new MasterComputer { ComputerID = 1, NamaComputer = "PC-001" },
                new MasterComputer { ComputerID = 2, NamaComputer = "PC-002" },
                new MasterComputer { ComputerID = 3, NamaComputer = "PC-003" },
                new MasterComputer { ComputerID = 4, NamaComputer = "Laptop-001" },
                new MasterComputer { ComputerID = 5, NamaComputer = "Laptop-002" }
            );

            builder.Entity<MasterPengguna>().HasData(
                new MasterPengguna { PenggunaID = 1, NamaPengguna = "Internal" },
                new MasterPengguna { PenggunaID = 2, NamaPengguna = "Eksternal" },
                new MasterPengguna { PenggunaID = 3, NamaPengguna = "Pribadi" }
            );
        }
    }
}

