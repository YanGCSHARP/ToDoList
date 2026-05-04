namespace ToDoWW.Domain.Entities;

public class TodoItem
{
    public Guid id { get; set;} = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } 
    public bool isCompleted { get; set; } = false;
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid RoomId { get; set; }
    public Room Room { get; set; } = null!;
}