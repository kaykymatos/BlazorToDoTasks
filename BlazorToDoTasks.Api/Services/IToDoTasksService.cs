using BlazorToDoTasks.Api.Models;

namespace BlazorToDoTasks.Api.Services
{
    public interface IToDoTasksService
    {
        Task<IEnumerable<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<IEnumerable<ErrorResponseModel>> CreateTask(TaskModel model);
        Task<IEnumerable<ErrorResponseModel>> UpdateTask(TaskModel model);
        Task<bool> DeleteTask(int id);
    }
}
