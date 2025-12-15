using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterPengguna
    {
        [Key]
        public int PenggunaID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaPengguna { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
