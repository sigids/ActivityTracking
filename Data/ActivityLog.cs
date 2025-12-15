using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTracking.Data
{
    public class ActivityLog
    {
        [Key]
        public int LogID { get; set; }

        [Required]
        public string UserID { get; set; } = string.Empty;

        [ForeignKey("UserID")]
        public virtual ApplicationUser? User { get; set; }

        [Required]
        public DateOnly Tanggal { get; set; }

        [MaxLength(50)]
        public string? ComputerNo { get; set; }

        public int? AktivitasID { get; set; }

        [ForeignKey("AktivitasID")]
        public virtual MasterActivity? Aktivitas { get; set; }

        [MaxLength(500)]
        public string? Deskripsi { get; set; }

        [MaxLength(200)]
        public string? DigunakanOleh { get; set; }

        [MaxLength(500)]
        public string? FilePath { get; set; }

        public TimeOnly? WaktuMulai { get; set; }

        public TimeOnly? WaktuSelesai { get; set; }

        public int DurasiMenit { get; set; }

        public int? FrekuensiID { get; set; }

        [ForeignKey("FrekuensiID")]
        public virtual MasterFrequency? Frekuensi { get; set; }

        public int? MetodeKerjaID { get; set; }

        [ForeignKey("MetodeKerjaID")]
        public virtual MasterWorkMethod? MetodeKerja { get; set; }

        public int? AplikasiID { get; set; }

        [ForeignKey("AplikasiID")]
        public virtual MasterApplication? Aplikasi { get; set; }

        [MaxLength(100)]
        public string? JenisDok { get; set; }

        [MaxLength(200)]
        public string? NamaDok { get; set; }

        [MaxLength(200)]
        public string? AsalDok { get; set; }

        [MaxLength(1000)]
        public string? Keterangan { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ActivityLogFile>? Files { get; set; }
    }
}
