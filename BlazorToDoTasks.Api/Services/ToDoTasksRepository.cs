using BlazorToDoTasks.Api.Extensions;
using BlazorToDoTasks.Api.Models;
using BlazorToDoTasks.Api.Repositories;
using FluentValidation;

namespace BlazorToDoTasks.Api.Services
{
    public class ToDoTasksService : IToDoTasksService
    {
        private readonly IToDoTasksRepository _repository;
        private readonly IValidator<TaskModel> _validator;

        public ToDoTasksService(IToDoTasksRepository repository, IValidator<TaskModel> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<ErrorResponseModel>> CreateTask(TaskModel entity)
        {
            var validation = _validator.Validate(entity);
            if (!validation.IsValid)
                return validation.Errors.ToCustomValidationFailure();

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
            var getModel = await _repository.GetTaskById(entity.Id);
            if (getModel == null)
                return [new ErrorResponseModel("Id", "Tarefa não encontrada!")];

            var validation = _validator.Validate(entity);
            if (!validation.IsValid)
                return validation.Errors.ToCustomValidationFailure();

            await _repository.UpdateTask(entity);
            return [];
        }
    }
}
