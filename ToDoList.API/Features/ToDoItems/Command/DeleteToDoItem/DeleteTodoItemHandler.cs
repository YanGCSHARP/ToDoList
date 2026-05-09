using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.API.Features.ToDoItems.Command.DeleteToDoItem;

public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, bool>
{
    private readonly AppDbContext _db;
    
    public DeleteTodoItemHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var item = _db.TodoItems.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken).Result;
        
        if (item is null) return false;
        
        _db.TodoItems.Remove(item);
        
        await _db.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}