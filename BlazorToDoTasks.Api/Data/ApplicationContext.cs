using BlazorToDoTasks.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoTasks.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>
           options) : base(options)
        { }
        public DbSet<TaskModel>? Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationContext).Assembly);
        }
    }
}
