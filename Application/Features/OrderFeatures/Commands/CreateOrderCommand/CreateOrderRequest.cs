using System;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderFeatures.Commands.CreateOrderCommand;

public sealed record CreateOrderRequest : IRequest<CreateOrderResponse>
{
    public ContactInfo Sender { get; set; } = new();
    public ContactInfo Receiver { get; set; } = new();
    public int Weight { get; set; }
    public DateTime DateTime { get; set; }
}