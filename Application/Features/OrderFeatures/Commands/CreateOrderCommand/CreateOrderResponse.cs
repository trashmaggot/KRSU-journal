using System;
using Application.Common.DTOs;
using Domain.Entities;

namespace Application.Features.OrderFeatures.Commands.CreateOrderCommand;

public sealed record CreateOrderResponse
{
    public ContactInfoDto Sender { get; set; } = null!;
    public ContactInfoDto Receiver { get; set; } = null!;
    public int Weight { get; set; }
    public DateTime DateTime { get; set; }
}