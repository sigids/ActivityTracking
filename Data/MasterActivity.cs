using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterActivity
    {
        [Key]
        public int AktivitasID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaAktivitas { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<ActivityLog>? ActivityLogs { get; set; }
    }
}
