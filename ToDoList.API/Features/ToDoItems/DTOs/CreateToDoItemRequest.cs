namespace ToDoList.API.Features.ToDoItems.DTOs;

public record CreateToDoItemRequest
(
    string Title,
    string Description,
    DateTime? DueDate,
    Guid RoomId
);