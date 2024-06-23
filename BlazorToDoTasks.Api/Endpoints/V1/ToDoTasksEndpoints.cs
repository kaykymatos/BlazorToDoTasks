using BlazorToDoTasks.Api.Models;
using BlazorToDoTasks.Api.Services;

namespace BlazorToDoTasks.Api.Endpoints.V1
{
    public static class ToDoTasksEndpoints
    {
        public static void ToDoTasks(this WebApplication app)
        {
            app.MapGet("api/v1/tasks", async (IToDoTasksService service) =>
            {
                return Results.Ok(await service.GetAllTasks());
            });
            app.MapGet("api/v1/tasks/{id:int}", async (IToDoTasksService service, int id) =>
            {
                return Results.Ok(await service.GetTaskById(id));
            });
            app.MapPost("api/v1/tasks", async (IToDoTasksService service, TaskModel model) =>
            {
                var reult = await service.CreateTask(model);
                return reult.Any() ? Results.BadRequest(reult) : Results.Ok(reult);

            });
            app.MapPut("api/v1/tasks", async (IToDoTasksService service, TaskModel model) =>
            {
                var reult = await service.UpdateTask(model);
                return reult.Any() ? Results.BadRequest(reult) : Results.Ok(reult);

            });
            app.MapDelete("api/v1/tasks/{id:int}", async (IToDoTasksService service, int id) =>
            {
                var reult = await service.DeleteTask(id);
                return !reult ? Results.BadRequest(reult) : Results.Ok(reult);
            });
        }
    }
}
