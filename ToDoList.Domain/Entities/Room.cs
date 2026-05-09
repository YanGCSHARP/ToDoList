namespace ToDoList.Domain.Entities;

public class Room : Base
{
    public string Name { get; set; } = string.Empty;
    
    public string Code { get; set; } = string.Empty;

    public List<TodoItem> Tasks { get; set; } = [];
    
    public List<UserRoom> Members { get; set; } = []; // ← это должно быть!
}