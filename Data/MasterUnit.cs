using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterUnit
    {
        [Key]
        public int UnitID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaUnit { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
