using Microsoft.AspNetCore.Mvc;
using TasksSystem.Models;
using TasksSystem.Repositories.Interfaces;

namespace TasksSystem.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            TaskModel task = await _taskRepository.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateTask([FromBody] TaskModel task)
        {
            TaskModel newTask = await _taskRepository.CreateTask(task);
            return Ok(newTask);
        }

        [HttpPut]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel task, int id) { 
            TaskModel dbTask = await _taskRepository.UpdateTask(task, id);
            return Ok(dbTask);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTask(int id)
        {
            bool hasDeleted = await _taskRepository.DeleteTask(id);
            return Ok(hasDeleted);
        }

    }
}
