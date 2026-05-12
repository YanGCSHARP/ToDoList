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
            .MaximumLength(500)
            .When(x => x.Description is not null);

        RuleFor(x => x.DueDate)
            .Must(d => d == null || d.Value >= DateTime.UtcNow.Date)
            .WithMessage("DueDate cannot be in the past.");
    }
}