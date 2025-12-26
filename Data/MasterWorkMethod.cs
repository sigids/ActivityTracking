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

        // Indicates whether this work method is computerized (true) or manual (false)
        public bool Computerize { get; set; } = false;

        public virtual ICollection<ActivityLog>? ActivityLogs { get; set; }
    }
}
