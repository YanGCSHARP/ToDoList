using Microsoft.VisualBasic;

namespace ToDoList.API.Features.ToDoItems.DTOs;

public record ToDoItemResponse
(
    Guid Id,
    string Title,
    string Description,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? DueDate,
    Guid RoomId
);