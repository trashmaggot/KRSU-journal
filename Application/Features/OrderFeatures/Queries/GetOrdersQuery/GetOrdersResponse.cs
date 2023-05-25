using System;
using Application.Common.DTOs;
using Domain.Entities;

namespace Application.Features.OrderFeatures.Queries.GetOrdersQuery;

public sealed record GetOrdersResponse
{
    public Guid Id { get; set; }
    public ContactInfoDto Sender { get; set; } = null!;
    public ContactInfoDto Receiver { get; set; } = null!;
    public int Weight { get; set; }
    public DateTime DateTime { get; set; }
}