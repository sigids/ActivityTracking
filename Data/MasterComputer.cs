using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterComputer
    {
        [Key]
        public int ComputerID { get; set; }

        [Required]
        [MaxLength(50)]
        public string NamaComputer { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
