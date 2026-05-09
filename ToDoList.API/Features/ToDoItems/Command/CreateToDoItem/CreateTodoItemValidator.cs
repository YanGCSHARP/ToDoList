using System.Data;
using FluentValidation;

namespace ToDoList.API.Features.ToDoItems.Command.CreateToDoItem;

public class CreateTodoItemValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemValidator()
    {
        RuleFor (x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
            .When(x => x.Description is not null);
        
        RuleFor(x => x.RoomId)
            .NotEmpty().WithMessage("RoomId is required.");
            
    }
}