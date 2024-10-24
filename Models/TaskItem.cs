using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuthentication.Models
{
    [Table("TaskItems")]
    public class TaskItem
    {
        [Key] 
        public int TaskID { get; set; }

        [Required, MaxLength(100)] 
        public string Title { get; set; }

        [MaxLength(500)] 
        public string? Description { get; set; }

        [Required]
        public string CreatedBy { get; set; } // User who created the task

        [Required] 
        public DateTime DueDate { get; set; } = DateTime.Now.ToLocalTime();

        public bool IsCompleted { get; set; } 
        [Required]
        public string ApplicationUserId { get; set; }

        [Required] 
        public int Priority { get; set; } // You can use an enum for better readability

        [MaxLength(50)] 
        public string? Category { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow.ToLocalTime();
    }
}
