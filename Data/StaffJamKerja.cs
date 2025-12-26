using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTracking.Data
{
    public class StaffJamKerja
    {
        [Key]
        public int JamKerjaID { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Required]
        public DateOnly Tanggal { get; set; }

        [Required]
        [Range(0, 24)]
        [Column(TypeName = "decimal(4,2)")]
        public decimal JamKerja { get; set; }

        [MaxLength(500)]
        public string? Keterangan { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}
