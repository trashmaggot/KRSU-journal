using System.Threading;
using System.Threading.Tasks;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderFeatures.Commands.CreateOrderCommand;

public sealed class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public CreateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request);
        await _orderRepository.CreateAsync(order, cancellationToken);
        return _mapper.Map<CreateOrderResponse>(order);
    }
}