using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Features.ToDoItems.DTOs;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.API.Features.ToDoItems.Command.UpdateToDoItem;

public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand, ToDoItemResponse?>
{
    private readonly AppDbContext _db;
    
    public UpdateTodoItemHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ToDoItemResponse> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _db.TodoItems.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (item is null) return null;
        
        item.Title = request.Title;
        item.Description = request.Description;
        item.IsCompleted = request.IsCompleted;
        item.DueDate = request.DueDate ?? item.DueDate;

        await _db.SaveChangesAsync(cancellationToken);
        
        return new ToDoItemResponse(
            item.Id,
            item.Title,
            item.Description,
            item.IsCompleted,
            item.CreatedAt,
            item.DueDate,
            item.RoomId
        );

    }
}