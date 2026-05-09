using MediatR;

namespace ToDoList.API.Features.ToDoItems.Command.DeleteToDoItem;

public record DeleteTodoItemCommand
(
    Guid Id
) : IRequest<bool>;