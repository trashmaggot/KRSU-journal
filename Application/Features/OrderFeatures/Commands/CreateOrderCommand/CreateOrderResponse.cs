using System;
using Domain.Entities;

namespace Application.Features.OrderFeatures.Commands.CreateOrderCommand;

public sealed record CreateOrderResponse
{
    public ContactInfo Sender { get; set; } = null!;
    public ContactInfo Receiver { get; set; } = null!;
    public int Weight { get; set; }
    public DateTime DateTime { get; set; }
}