using MediatR;
using ToDoList.API.Features.Rooms.DTOs;

using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.API.Features.Rooms.Command.CreateRoom;

public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, CreateRoomResponse>
{
    private readonly AppDbContext _db;
    
    public CreateRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<CreateRoomResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = new Room
        {
            Name = request.Name,
            Code = Guid.NewGuid().ToString("N")[..8].ToUpper()
        };

        _db.Rooms.Add(room);
        await _db.SaveChangesAsync(cancellationToken);
        
        return new CreateRoomResponse(room.Id, room.Name, room.Code, room.CreatedAt);

    }
}