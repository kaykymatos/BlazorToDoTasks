using BlazorToDoTasks.Client.ViewModels;

namespace BlazorToDoTasks.Client.Services
{
    public interface IToDoTasksService
    {
        Task<IEnumerable<TaskViewModel>> GetAllTasks();
        Task<TaskViewModel> GetTaskById(int id);
        Task<IEnumerable<ErrorResponseViewModel>> CreateTask(TaskViewModel model);
        Task<IEnumerable<ErrorResponseViewModel>> UpdateTask(TaskViewModel model);
        Task<bool> DeleteTask(int id);
    }
}
