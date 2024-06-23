using BlazorToDoTasks.Api.Data;
using BlazorToDoTasks.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoTasks.Api.Repositories
{
    public class ToDoTasksRepository : IToDoTasksRepository
    {
        private readonly ApplicationContext _context;

        public ToDoTasksRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> CreateTask(TaskModel entity)
        {
            _context.Tasks.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<TaskModel> DeleteTask(TaskModel entity)
        {
            _context.ChangeTracker.Clear();
            _context.Tasks.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> UpdateTask(TaskModel entity)
        {
            _context.ChangeTracker.Clear();
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
