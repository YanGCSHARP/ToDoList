using MediatR;
using ToDoList.API.Features.Rooms.DTOs;

namespace ToDoList.API.Features.Rooms.Command.DeleteRoom;

public record DeleteRoomCommand (Guid Id) : IRequest<bool>;