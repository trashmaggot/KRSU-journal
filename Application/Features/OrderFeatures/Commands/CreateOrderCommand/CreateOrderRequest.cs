using System;
using Application.Common.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderFeatures.Commands.CreateOrderCommand;

public sealed record CreateOrderRequest : IRequest<CreateOrderResponse>
{
    public ContactInfoDto Sender { get; set; } = new();
    public ContactInfoDto Receiver { get; set; } = new();
    public int Weight { get; set; }
    public DateTime DateTime { get; set; }
}