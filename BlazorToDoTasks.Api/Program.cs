using BlazorToDoTasks.Api.Data;
using BlazorToDoTasks.Api.Endpoints.V1;
using BlazorToDoTasks.Api.Models;
using BlazorToDoTasks.Api.Repositories;
using BlazorToDoTasks.Api.Services;
using BlazorToDoTasks.Api.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationContext>(opt =>
                                opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnectionString"),
                        x => x.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

builder.Services.AddScoped<IToDoTasksRepository, ToDoTasksRepository>();
builder.Services.AddScoped<IToDoTasksService, ToDoTasksService>();
builder.Services.AddTransient<IValidator<TaskModel>, TaskValidation>();
var app = builder.Build();

app.ToDoTasks();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.Run();