using System;
using Domain.Entities;

namespace Application.Features.OrderFeatures.Queries.GetOrdersQuery;

public sealed record GetOrdersResponse
{
    public Guid Id { get; set; }
    public ContactInfo Sender { get; set; } = null!;
    public ContactInfo Receiver { get; set; } = null!;
    public int Weight { get; set; }
    public DateTime DateTime { get; set; }
}