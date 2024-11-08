﻿namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.DeleteApiary;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.UpdateApiary;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaries;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaryById;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Apiaries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetApiaries)
            .MapGet(GetApiaryById, "{id}")
            .MapPost(CreateApiary)
            .MapPut(UpdateApiary, "{id}")
            .MapDelete(DeleteApiary, "{id}");
    }
    public async Task<PaginatedList<ApiaryModel>> GetApiaries(ISender sender, [AsParameters] GetApiariesQuery query)
        => await sender.Send(query);

    public async Task<ApiaryModel> GetApiaryById(ISender sender, Guid id)
        => await sender.Send(new GetApiaryByIdQuery() { ApiaryId = id });

    public async Task<Guid> CreateApiary(ISender sender, CreateApiaryCommand command)
        => await sender.Send(command);

    public async Task<IResult> UpdateApiary(ISender sender, Guid id, UpdateApiaryCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest();
        }

        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> DeleteApiary(ISender sender, Guid id)
    {
        await sender.Send(new DeleteApiaryCommand() { Id = id });
        return Results.Ok();
    }
}
