using MediatR;
using Microsoft.EntityFrameworkCore;

using ToDoList.API.Features.ToDoItems.DTOs;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.API.Features.TodoItems.Queries.GetTodoItemById;

public class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemByIdQuery, ToDoItemResponse?>
{
    private readonly AppDbContext _db;

    public GetTodoItemByIdHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ToDoItemResponse?> Handle(GetTodoItemByIdQuery request, CancellationToken ct)
    {
        return await _db.TodoItems
            .Where(t => t.Id == request.Id)
            .Select(t => new ToDoItemResponse(
                t.Id,
                t.Title,
                t.Description,
                t.IsCompleted,
                t.DueDate,
                t.CreatedAt,
                t.RoomId))
            .FirstOrDefaultAsync(ct);
    }
}