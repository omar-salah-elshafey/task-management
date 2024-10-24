using System.ComponentModel.DataAnnotations;

namespace UserAuthentication.Models
{
    public class TaskItemDTO
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; } = DateTime.Now.ToLocalTime();
        [Required]
        public int Priority { get; set; } // You can use an enum for better readability

        public bool IsCompleted { get; set; } = false;
        [MaxLength(50)]
        public string? Category { get; set; }
    }
}
