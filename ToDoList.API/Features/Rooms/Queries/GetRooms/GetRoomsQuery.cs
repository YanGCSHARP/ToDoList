using MediatR;
using ToDoList.API.Features.Rooms.DTOs;

namespace ToDoList.API.Features.Rooms.Queries.GetRooms;

public record GetRoomsQuery : IRequest<List<CreateRoomResponse>>;