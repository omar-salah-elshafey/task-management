using UserAuthentication.Models;

namespace UserAuthentication.Services
{
    public interface ITaskService
    {
        Task<TaskItem> CreateTaskAsync(TaskItemDTO taskItemDTO, string userName, string userId);
        Task<List<TaskItem>> GetAllTasksAsync(string userId);
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task<TaskItem> UpdateTaskAsync(int id, TaskItemDTO taskItemDTO, string userName, string userId);
        Task<bool> DeleteTaskAsync(int id);

    }
}
