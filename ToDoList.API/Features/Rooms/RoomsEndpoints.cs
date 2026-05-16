using MediatR;
using ToDoList.API.Features.Rooms.Command.CreateRoom;
using ToDoList.API.Features.Rooms.Command.DeleteRoom;
using ToDoList.API.Features.Rooms.Command.UpdateRoom;
using ToDoList.API.Features.Rooms.DTOs;
using ToDoList.API.Features.Rooms.Queries.GetRooms;

namespace ToDoList.API.Features.Rooms;

public static class RoomsEndpoints
{
    public static void MapRoomsEndpoints(this WebApplication app)
    {
        var group1 = app.MapGroup("/api/rooms").WithTags("Rooms");
        
        group1.MapPost("/", async (CreateRoomRequest request, IMediator mediator) =>
        {
            var result = await mediator.Send(new CreateRoomCommand(request.Name));
            return Results.Created($"/api/rooms/{result.Id}", result);
        });

        group1.MapGet("/", async (IMediator mediator) =>
        {
            var rooms = await mediator.Send(new GetRoomsQuery());
            return Results.Ok(rooms);
        });

        group1.MapPut("/{id:guid}", async (Guid id,UpdateRoomRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new UpdateRoomCommand(id, request.Name));
                return result is null ? Results.NotFound() : Results.Ok(result);
            }
        );

        group1.MapDelete("/{id:guid}", async (Guid id, IMediator meditor) =>
            {
                var result = await meditor.Send(new DeleteRoomCommand(id));
                return result ? Results.NotFound() : Results.NoContent();
            }
        );
    }
}