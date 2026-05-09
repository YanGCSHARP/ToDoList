using MediatR;
using ToDoList.API.Features.ToDoItems.Command.CreateToDoItem;
using ToDoList.API.Features.ToDoItems.Command.DeleteToDoItem;
using ToDoList.API.Features.ToDoItems.Command.UpdateToDoItem;
using ToDoList.API.Features.ToDoItems.DTOs;
using ToDoList.API.Features.TodoItems.Queries.GetAllTodoItems;
using ToDoList.API.Features.TodoItems.Queries.GetTodoItemById;

namespace ToDoList.API.Features.ToDoItems;

public static class ToDoItemsEndpoints
{
    public static void MapToDoItemEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/todoitems").WithTags("ToDoItems");
        
        group.MapGet("/room/{roomId:guid}", async (Guid roomId, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllTodoItemsQuery(roomId));
            return Results.Ok(result);
        });
        group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetTodoItemByIdQuery(id));
            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        group.MapPost("/", async (CreateToDoItemRequest request, IMediator mediator) =>
        {
            var command = new CreateTodoItemCommand(
                request.Title,
                request.Description,
                request.DueDate,
                request.RoomId);
            var result = await mediator.Send(command);
            return Results.Created($"/api/todoitems/{result.Id}", result);
        });
        
        group.MapPut("/{id:guid}", async (Guid id, UpdateToDoItemRequest request, IMediator mediator) =>
        {
            var command = new UpdateTodoItemCommand(
                id,
                request.Title,
                request.Description,
                request.IsCompleted,
                request.DueDate);
            var result = await mediator.Send(command);
            return result is null ? Results.NotFound() : Results.Ok(result);
        });
        
        group.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new DeleteTodoItemCommand(id));
            return result ? Results.NoContent() : Results.NotFound();
        });
    }
}