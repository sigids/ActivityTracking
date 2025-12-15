using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterWorkMethod
    {
        [Key]
        public int MethodID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaMetode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<ActivityLog>? ActivityLogs { get; set; }
    }
}
