﻿namespace ApiaryManagementSystem.Application.Features.Inspections.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Inspections;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class InspectionCreatedEventHandler(ILogger<InspectionCreatedEventHandler> logger) : INotificationHandler<InspectionCreatedEvent>
{
    public Task Handle(InspectionCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
