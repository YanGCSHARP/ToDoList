namespace ToDoList.API.Features.Rooms.DTOs;

public record CreateRoomResponse(
    Guid Id,
    string Name,
    string Code,
    DateTime CreatedAt
);