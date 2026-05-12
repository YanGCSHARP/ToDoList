using MediatR;
using ToDoList.API.Features.ToDoItems.DTOs;
namespace ToDoList.API.Features.ToDoItems.Command.UpdateToDoItem;

public record UpdateTodoItemCommand
(
    Guid Id,
    string Title,
    string Description,
    bool IsCompleted,
    DateTime? DueDate
) : IRequest<ToDoItemResponse?>;