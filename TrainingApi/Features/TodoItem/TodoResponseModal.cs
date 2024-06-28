namespace TrainingApi.Features.TodoItem
{
    public class TodoResponseModal
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TodoItem TodoItem { get; set; }
    }
}
