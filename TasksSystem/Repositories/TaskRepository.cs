using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TasksSystem.Data;
using TasksSystem.Models;
using TasksSystem.Repositories.Interfaces;

namespace TasksSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            TaskModel task = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id);
            return task;
        }
        public async Task<TaskModel> CreateTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel selectedTask = await GetTaskById(id);

            if(selectedTask == null)
            {
                throw new Exception($"The task with id {id} was not found!");
            }

            selectedTask.Status = task.Status;
            selectedTask.Name = task.Name;
            selectedTask.UserId = task.UserId;
            selectedTask.Description = task.Description;

            _dbContext.Tasks.Update(selectedTask);
            await _dbContext.SaveChangesAsync();

            return selectedTask;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel task = await this.GetTaskById(id);

            if (task == null)
            {
                throw new Exception($"The task with id {id} was not founded!");
            }

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();

            return true;
        }


    }
}
