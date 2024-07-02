using FluentValidation;

namespace TrainingApi.Features.TodoItem
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; } 
    }

    public class TodoItemValidator : AbstractValidator<TodoItem>
    {
        public TodoItemValidator()
        {
            RuleFor(todo => todo.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("title is required");

            RuleFor(todo => todo.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("description must be defined");

            RuleFor(todo => todo.IsComplete)
                .NotNull()
                .WithMessage("need to define completed or not");

            
        }
    }
    
}
