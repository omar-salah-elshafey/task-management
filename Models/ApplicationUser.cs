using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UserAuthentication.Models;

namespace UserAuthenticationApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow.ToLocalTime();
        public bool IsActive { get; set; }
        public string? ProfileImageUrl { get; set; }
        public List<TaskItem>? TaskItems { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}
