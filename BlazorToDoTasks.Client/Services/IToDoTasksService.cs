using BlazorToDoTasks.Client.ViewModels;

namespace BlazorToDoTasks.Client.Services
{
    public interface IToDoTasksService
    {
        Task<List<TaskViewModel>> GetAllTasks();
        Task<TaskViewModel> GetTaskById(int id);
        Task<List<ErrorResponseViewModel>> CreateTask(TaskViewModel model);
        Task<List<ErrorResponseViewModel>> UpdateTask(TaskViewModel model);
        Task<bool> DeleteTask(int id);
    }
}
