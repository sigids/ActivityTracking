using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterJenisDok
    {
        [Key]
        public int JenisDokID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaJenisDok { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
