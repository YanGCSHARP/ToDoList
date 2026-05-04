namespace ToDoWW.Domain.Entities;

public class UserRoom
{
    public Guid UserId { get; set; }
    public Guid RoomId { get; set; }

    public Room Room { get; set; } = null!;
    public string Role { get; set; } = "Member"; // Default role is "Member"
}