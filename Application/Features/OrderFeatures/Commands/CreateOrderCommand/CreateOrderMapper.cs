using AutoMapper;
using Domain.Entities;

namespace Application.Features.OrderFeatures.Commands.CreateOrderCommand;

public sealed class CreateOrderMapper : Profile
{
    public CreateOrderMapper()
    {
        CreateMap<CreateOrderRequest, Order>();
        CreateMap<Order, CreateOrderResponse>();
    }
}