using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.OrderFeatures.Queries.GetOrdersQuery;

public class GetOrdersHandler : IRequestHandler<GetOrdersRequest, List<GetOrdersResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<GetOrdersResponse>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetOrdersResponse>>(orders);
    }
}