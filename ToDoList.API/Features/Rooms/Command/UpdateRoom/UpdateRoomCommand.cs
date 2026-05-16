using MediatR;
using ToDoList.API.Features.Rooms.DTOs;

namespace ToDoList.API.Features.Rooms.Command.UpdateRoom;

public record UpdateRoomCommand(Guid Id, string Name ) : IRequest<RoomResponse?>;