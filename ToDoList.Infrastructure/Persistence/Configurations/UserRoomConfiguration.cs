using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Persistence.Configurations;

public class UserRoomConfiguration : IEntityTypeConfiguration<UserRoom>
{
    public void Configure(EntityTypeBuilder<UserRoom> builder)
    {
        // Составной ключ
        builder.HasKey(ur => new { ur.UserId, ur.RoomId });

        builder.Property(ur => ur.Role)
            .HasMaxLength(20)
            .HasDefaultValue("Member");

        builder.HasOne(ur => ur.User)
            .WithMany(u => u.Rooms)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ur => ur.Room)
            .WithMany(r => r.Members)
            .HasForeignKey(ur => ur.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}