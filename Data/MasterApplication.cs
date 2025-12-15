using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterApplication
    {
        [Key]
        public int ApplicationID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaAplikasi { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<ActivityLog>? ActivityLogs { get; set; }
    }
}
