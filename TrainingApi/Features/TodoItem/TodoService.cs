using Microsoft.EntityFrameworkCore;
using TrainingApi.Data;

namespace TrainingApi.Features.TodoItem
{
    public class TodoService : ITodoService
    {
        private readonly TrainingApiDbContext _context;

        public TodoService(TrainingApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateATodo(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
            return await Save();
        }

        public async Task<TodoItem> GetById(long Id)
        {
            return await _context.TodoItems.FindAsync(Id);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<List<TodoItem>> GetAllTodoItems()
        {
            return  await _context.TodoItems.ToListAsync();
        }

        public async Task<bool> EditTodo(long Id,TodoItem todoItem)
        {
            var modal = await _context.TodoItems.FindAsync(Id);
            if(modal == null)
                return false;

            modal.Title = todoItem.Title;
            modal.Description = todoItem.Description;
            modal.IsComplete = todoItem.IsComplete;
            return await Save();
        }

        public async Task<bool> DeleteById(long Id)
        {
            var modal = await _context.TodoItems.FindAsync(Id);
            _context.TodoItems.Remove(modal);
            return await Save();
        }
    }
}
