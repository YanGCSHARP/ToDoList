using MediatR;
using ToDoList.API.Features.ToDoItems.DTOs;
using ToDoList.API.Features.ToDoItems.Queries;

namespace ToDoList.API.Features.TodoItems.Queries.GetTodoItemById;

public record GetTodoItemByIdQuery(Guid Id) : IRequest<ToDoItemResponse?>;