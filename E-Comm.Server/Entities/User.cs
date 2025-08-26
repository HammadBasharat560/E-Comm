using System.ComponentModel.DataAnnotations;

namespace E_Comm.Server.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsEmailConfirmed { get; set; }
        public string? EmailVerificationCode { get; set; }
        public DateTime? EmailVerificationExpiry { get; set; }

        public string? PhoneNumber { get; set; }
        public string? CompanyName { get; set; }

        public bool? IsApproved { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public int? ApprovedBy { get; set; }

        public UserRole Role { get; set; }

        // Two-Factor Auth (future use)
        public string? TwoFactorSecretKey { get; set; }
        public bool IsTwoFactorEnabled { get; set; }

        // Soft delete (optional)
        public bool IsDeleted { get; set; }

        // For login tracking
        public DateTime? LastLoginAt { get; set; }
    }

    public enum UserRole
    {
        User = 5,
        Seller = 10,
        Admin = 15,
        SuperAdmin = 20
    }
}
