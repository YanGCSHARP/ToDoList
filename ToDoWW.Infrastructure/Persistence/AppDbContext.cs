using Microsoft.EntityFrameworkCore;
using ToDoWW.Domain.Entities;

namespace ToDoWW.Infrastructure.Persistence;

public class AppDbContext : DbContext{
    
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Room> => Set<Room>();
    public DbSet<TodoItem> => Set<TodoItem>();
    public DbSet<UserRoom> => Set<UserRoom>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
}