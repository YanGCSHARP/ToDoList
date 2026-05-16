namespace ToDoList.API.Features.ToDoItems.DTOs;

public record UpdateToDoItemRequest
(
    string Title,
    string Description,
    bool IsCompleted,
    DateTime? DueDate
);