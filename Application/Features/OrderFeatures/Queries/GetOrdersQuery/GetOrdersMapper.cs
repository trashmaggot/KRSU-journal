using Application.Common.DTOs;
using Application.Features.OrderFeatures.Commands.CreateOrderCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.OrderFeatures.Queries.GetOrdersQuery;

public sealed class GetOrdersMapper : Profile
{
    public GetOrdersMapper()
    {
        CreateMap<Order, GetOrdersResponse>();
        CreateMap<ContactInfo, ContactInfoDto>();
    }
}