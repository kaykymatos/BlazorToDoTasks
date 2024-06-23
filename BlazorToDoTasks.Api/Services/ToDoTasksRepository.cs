using BlazorToDoTasks.Api.Models;
using BlazorToDoTasks.Api.Repositories;

namespace BlazorToDoTasks.Api.Services
{
    public class ToDoTasksService : IToDoTasksService
    {
        private readonly IToDoTasksRepository _repository;

        public ToDoTasksService(IToDoTasksRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ErrorResponseModel>> CreateTask(TaskModel entity)
        {
            await _repository.CreateTask(entity);
            return [];
        }

        public async Task<bool> DeleteTask(int id)
        {
            var entity = await _repository.GetTaskById(id);
            if (entity == null)
                return false;
            await _repository.DeleteTask(entity);
            return true;
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
            return await _repository.GetAllTasks();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _repository.GetTaskById(id);
        }

        public async Task<IEnumerable<ErrorResponseModel>> UpdateTask(TaskModel entity)
        {
            await _repository.UpdateTask(entity);
            return [];
        }
    }
}
