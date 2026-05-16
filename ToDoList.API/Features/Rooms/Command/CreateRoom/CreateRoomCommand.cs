using MediatR;
using ToDoList.API.Features.Rooms.DTOs;


namespace ToDoList.API.Features.Rooms.Command.CreateRoom;

public record CreateRoomCommand(string Name) : IRequest<RoomResponse>;