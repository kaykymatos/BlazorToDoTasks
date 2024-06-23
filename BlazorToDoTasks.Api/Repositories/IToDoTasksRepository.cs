using BlazorToDoTasks.Api.Models;

namespace BlazorToDoTasks.Api.Repositories
{
    public interface IToDoTasksRepository
    {
        Task<TaskModel> GetTaskById(int id);
        Task<IEnumerable<TaskModel>> GetAllTasks();
        Task<TaskModel> CreateTask(TaskModel entity);
        Task<TaskModel> UpdateTask(TaskModel entity);
        Task<TaskModel> DeleteTask(TaskModel entity);
    }
}
