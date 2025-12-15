using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterJabatan
    {
        [Key]
        public int JabatanID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaJabatan { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
