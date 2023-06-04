using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasksSystem.Models;

namespace TasksSystem.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder) {
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Name).IsRequired().HasMaxLength(255);
            builder.Property(task => task.Description).HasMaxLength(1000);
            builder.Property(task => task.Status).IsRequired();
            builder.Property(task => task.UserId);

            builder.HasOne(task => task.User);
        }
    }
}
