using MediatR;
using ToDoList.API.Features.Rooms.DTOs;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.API.Features.Rooms.Command.UpdateRoom;

public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand, RoomResponse?>
{
    private readonly AppDbContext _db;

    public UpdateRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<RoomResponse?> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _db.Rooms.FindAsync(new object[] {request.Id}, cancellationToken);
        
        if (room is null) return null;
        
        room.Name = request.Name;

        await _db.SaveChangesAsync(cancellationToken);

        return new RoomResponse(room.Id, room.Name, room.Code, room.CreatedAt);

    }
} 