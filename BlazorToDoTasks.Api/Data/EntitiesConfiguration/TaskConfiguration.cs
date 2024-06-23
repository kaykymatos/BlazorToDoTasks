using BlazorToDoTasks.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorToDoTasks.Api.Data.EntitiesConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.StartDate).IsRequired().HasColumnType("date");
            builder.Property(x => x.EndDate).IsRequired().HasColumnType("date");
        }
    }
}
