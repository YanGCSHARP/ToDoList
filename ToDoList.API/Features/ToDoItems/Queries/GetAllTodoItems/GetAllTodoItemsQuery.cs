using MediatR;
using ToDoList.API.Features.ToDoItems.DTOs;

namespace ToDoList.API.Features.TodoItems.Queries.GetAllTodoItems;

public record GetAllTodoItemsQuery(Guid RoomId) : IRequest<List<ToDoItemResponse>>;