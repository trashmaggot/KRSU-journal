using System.Collections.Generic;
using MediatR;

namespace Application.Features.OrderFeatures.Queries.GetOrdersQuery;

public sealed record GetOrdersRequest : IRequest<List<GetOrdersResponse>>;