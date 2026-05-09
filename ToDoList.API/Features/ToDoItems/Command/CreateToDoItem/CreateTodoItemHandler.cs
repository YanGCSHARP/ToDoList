using MediatR;
using ToDoList.API.Features.ToDoItems.DTOs;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Persistence;
namespace ToDoList.API.Features.ToDoItems.Command.CreateToDoItem;

public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand,ToDoItemResponse>
{
    private readonly AppDbContext _db;

    public CreateTodoItemHandler(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<ToDoItemResponse> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var item = new TodoItem
        {
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate ?? DateTime.UtcNow.AddDays(1),
            RoomId = request.RoomId
        };

        _db.TodoItems.Add(item);
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