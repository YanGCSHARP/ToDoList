namespace ToDoWW.Domain.Entities;

public class Room
{
    public Guid id  { get; set;} = Guid.NewGuid();
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<TodoItem> Tasks { get; set; } = [];
    public List<UserRoom> UserRooms { get; set; } = [];
}