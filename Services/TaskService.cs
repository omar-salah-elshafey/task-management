using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAuthentication.Models;
using UserAuthenticationApp.Models;

namespace UserAuthentication.Services
{
    public class TaskService: ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TaskService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItemDTO taskItemDTO, string userName, string userId)
        {
            var taskItem = new TaskItem();
            taskItem.Title = taskItemDTO.Title;
            taskItem.Description = taskItemDTO.Description;
            taskItem.CreatedBy = userName; // Associate the task with the user
            taskItem.DueDate = taskItemDTO.DueDate;
            taskItem.ApplicationUserId = userId;
            taskItem.Priority = taskItemDTO.Priority;
            taskItem.Category = taskItemDTO.Category;
            taskItem.DateCreated = DateTime.Now.ToLocalTime();
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync(string userName)
        {
            return await _context.TaskItems
                .Where(t => t.CreatedBy == userName) // Filter tasks by user ID
                .ToListAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task<TaskItem> UpdateTaskAsync(int id, TaskItemDTO taskItemDTO, string userName, string userId)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
                return new TaskItem { Category = "No" };
            taskItem.Title = taskItemDTO.Title;
            taskItem.Description = taskItemDTO.Description;
            taskItem.CreatedBy = userName;
            taskItem.DueDate = taskItemDTO.DueDate;
            taskItem.ApplicationUserId = userId;
            taskItem.Priority = taskItemDTO.Priority;
            taskItem.Category = taskItemDTO.Category;
            taskItem.IsCompleted = taskItemDTO.IsCompleted;
            await _context.SaveChangesAsync();
            
            return taskItem; // Return true if updated
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null) return false;

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
            return true; // Return true if deleted
        }
    }
}
