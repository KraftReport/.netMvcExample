namespace TrainingApi.Features.TodoItem
{
    public interface ITodoService
    {
        public Task<bool> CreateATodo(TodoItem todoItem);
        public Task<TodoItem> GetById(long Id);
        public Task<List<TodoItem>> GetAllTodoItems();
        public Task<bool> EditTodo(long Id,TodoItem todoItem);
        public Task<bool> DeleteById(long Id);
    }
}
