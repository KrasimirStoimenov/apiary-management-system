﻿namespace ApiaryManagementSystem.Domain.Models.Hives;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Apiaries;

public sealed class Hive(
    string number,
    string type,
    string status,
    string? color,
    DateOnly dateBought,
    Guid apiaryId) : BaseAuditableEntity
{
    public string Number { get; private set; } = number;

    public string Type { get; private set; } = type;

    public string Status { get; private set; } = status;

    public string? Color { get; private set; } = color;

    public DateOnly DateBought { get; private set; } = dateBought;

    public Guid ApiaryId { get; private set; } = apiaryId;

    public Apiary Apiary { get; init; } = null!;    // Required reference navigation to principal

    public void UpdateHive(
        string number,
        string type,
        string status,
        string? color,
        DateOnly dateBought,
        Guid apiaryId)
    {
        this.Number = number;
        this.Type = type;
        this.Status = status;
        this.Color = color;
        this.DateBought = dateBought;
        this.ApiaryId = apiaryId;
    }
}
