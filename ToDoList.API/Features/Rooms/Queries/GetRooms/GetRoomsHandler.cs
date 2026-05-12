using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Features.Rooms.DTOs;

using ToDoList.Infrastructure.Persistence;

namespace ToDoList.API.Features.Rooms.Queries.GetRooms;

public class GetRoomsHandler : IRequestHandler<GetRoomsQuery, List<CreateRoomResponse>>
{
    private readonly AppDbContext _db;
    
    public GetRoomsHandler (AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<CreateRoomResponse>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
    {
        return await _db.Rooms
            .Select(r => new CreateRoomResponse(r.Id, r.Name, r.Code, r.CreatedAt))
            .ToListAsync(cancellationToken);
        
        
    }
}