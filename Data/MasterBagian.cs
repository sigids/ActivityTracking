using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class MasterBagian
    {
        [Key]
        public int BagianID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NamaBagian { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
