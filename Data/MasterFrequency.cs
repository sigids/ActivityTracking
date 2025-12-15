using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterFrequency
    {
        [Key]
        public int FrequencyID { get; set; }

        [Required]
        [MaxLength(50)]
        public string NamaFrekuensi { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<ActivityLog>? ActivityLogs { get; set; }
    }
}
