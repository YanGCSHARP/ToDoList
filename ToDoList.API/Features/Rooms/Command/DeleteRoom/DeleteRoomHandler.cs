using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.API.Features.Rooms.Command.DeleteRoom;

public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand, bool>
{
    private readonly AppDbContext _db;

    public DeleteRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _db.Rooms
            .FirstOrDefaultAsync(x => x.Id == request.Id  , cancellationToken);
        if (room is null) return false;

        _db.Rooms.Remove(room);
        
        await _db.SaveChangesAsync(cancellationToken);
        
        return true;

    }
}