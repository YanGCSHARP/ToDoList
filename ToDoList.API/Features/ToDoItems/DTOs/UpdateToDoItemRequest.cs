namespace ToDoList.API.Features.ToDoItems.DTOs;

public record UpdateToDoItemRequest
(
    Guid Id,
    string Title,
    string Description,
    bool IsCompleted,
    DateTime? DueDate
);