using MediatR;

namespace Application.Features.GroupFeatures.Queries.GetGroupStudentsQuery;

public class GetGroupStudentsRequest : IRequest<List<GetGroupStudentsResponse>>
{
    public Guid GroupId { get; set; }
}