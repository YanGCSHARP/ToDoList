using MediatR;
using ToDoList.API.Features.ToDoItems.DTOs;
namespace ToDoList.API.Features.ToDoItems.Command.CreateToDoItem;

public record CreateTodoItemCommand
(
    string Title,
    string? Description,
    DateTime? DueDate,
    Guid RoomId
) : IRequest<ToDoItemResponse>;