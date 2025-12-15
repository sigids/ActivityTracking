using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ActivityTracking.Data
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string? EmployeeID { get; set; }

        [MaxLength(100)]
        public string? Nama { get; set; }

        [MaxLength(100)]
        public string? Jabatan { get; set; }

        [MaxLength(100)]
        public string? Bagian { get; set; }

        [MaxLength(100)]
        public string? Unit { get; set; }

        [MaxLength(20)]
        public string? TipeKaryawan { get; set; } // Monthly, Daily

        [MaxLength(20)]
        public string? KomputerType { get; set; } // Dedicated, Shared

        [MaxLength(50)]
        public string? KomputerNo { get; set; } // Default computer for Dedicated users

        [MaxLength(20)]
        public string Role { get; set; } = "Staff"; // Admin, Staff

        public virtual ICollection<ActivityLog>? ActivityLogs { get; set; }
    }
}

