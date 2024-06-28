using Microsoft.EntityFrameworkCore;
using TrainingApi.Features.TodoItem;

namespace TrainingApi.Data
{
    public class TrainingApiDbContext : DbContext
    {
        public TrainingApiDbContext(DbContextOptions<TrainingApiDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
