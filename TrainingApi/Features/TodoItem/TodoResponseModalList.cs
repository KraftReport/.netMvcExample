namespace TrainingApi.Features.TodoItem
{
    public class TodoResponseModalList
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<TodoItem> TodoItems { get; set; }
    }
}
