using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserAuthentication.Models;
using UserAuthentication.Services;

namespace UserAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTask([FromBody] TaskItemDTO taskItemDTO)
        {
            if (taskItemDTO == null)
                return BadRequest("Task item is null.");
            var userId = Request.Cookies["userId"];
            var userName = Request.Cookies["UserName"];
            var createdTask = await _taskService.CreateTaskAsync(taskItemDTO, userName, userId);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.TaskID }, createdTask);
        }

        [HttpGet("get-tasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var userName = Request.Cookies["userName"];
            var tasks = await _taskService.GetAllTasksAsync(userName);
            return Ok(tasks);
        }

        [HttpGet("get-task-by-id")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        } 

        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItemDTO taskItemDTO)
        {
            if (taskItemDTO == null || id <= 0)
                return BadRequest("Id and Item Details are required!");
            var userId = Request.Cookies["userId"];
            var userName = Request.Cookies["UserName"];
            var updated = await _taskService.UpdateTaskAsync(id, taskItemDTO, userName, userId);
            if (updated.Category.Equals("No"))
                return BadRequest("Item not found!");
            return Ok(updated);
        }

        [HttpDelete("delete-task")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteTaskAsync(id);
            if (!deleted) return NotFound();

            return Ok("TaskItem has been deleted Successfully.");
        }
    }
}
