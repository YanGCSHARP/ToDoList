using FluentValidation;

namespace ToDoList.API.Features.ToDoItems.Command.UpdateToDoItem;

public class UpdateTodoItemValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            

        RuleFor(x => x.DueDate)
            .Must(d => d == null || d.Value >= DateTime.UtcNow.Date)
            .WithMessage("DueDate cannot be in the past.");
    }
}