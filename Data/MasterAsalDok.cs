using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterAsalDok
    {
        [Key]
        public int AsalDokID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaAsalDok { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
