using System.ComponentModel.DataAnnotations;

namespace UserAuthentication.Models
{
    public class UpdateUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
