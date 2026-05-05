namespace ToDoList.Domain.Entities;

public class User : Base
{
    public string Email { get; set; } = string.Empty;
    
    public string PasswordHash { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    
    public List<UserRoom> Rooms { get; set; } = [];
}