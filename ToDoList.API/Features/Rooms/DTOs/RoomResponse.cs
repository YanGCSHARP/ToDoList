namespace ToDoList.API.Features.Rooms.DTOs;

public record RoomResponse(
    Guid Id,
    string Name,
    string Code,
    DateTime CreatedAt
);