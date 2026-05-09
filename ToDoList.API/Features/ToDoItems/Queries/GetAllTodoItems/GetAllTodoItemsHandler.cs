using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Features.ToDoItems.DTOs;
using ToDoList.API.Features.TodoItems.Queries.GetAllTodoItems;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.API.Features.ToDoItems.Queries.GetAllTodoItems;

public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, List<ToDoItemResponse>>
{
    private readonly AppDbContext _db;
    
    public GetAllTodoItemsHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<ToDoItemResponse>> Handle(GetAllTodoItemsQuery request,
        CancellationToken cancellationToken)
    {
        return await _db.TodoItems
            .Where(t => t.RoomId == request.RoomId)
            .Select(t => new ToDoItemResponse(
                t.Id,
                t.Title,
                t.Description,
                t.IsCompleted,
                t.CreatedAt,
                t.DueDate,
                t.RoomId))
            .ToListAsync(cancellationToken);
    }
}