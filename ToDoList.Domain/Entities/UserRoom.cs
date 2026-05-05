namespace ToDoList.Domain.Entities;

public class UserRoom
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid RoomId { get; set; }

    public Room Room { get; set; } = null!;
    public string Role { get; set; } = "Member"; // будут роли, лидер комнаты, и участиники 
}