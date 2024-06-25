using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GroupFeatures.Queries.GetGroupsQuery;

public class GetGroupsHandler : IRequestHandler<GetGroupsRequest, List<GroupDto>>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupsHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<List<GroupDto>> Handle(GetGroupsRequest request, CancellationToken cancellationToken)
    {
        var groups = await _groupRepository.GetAll().ToListAsync(cancellationToken);
        return groups.Select(group => new GroupDto { Id = group.Id, Name = group.Name }).ToList();
    }
}

public class GetGroupsRequest : IRequest<List<GroupDto>>
{
    
}

public class GroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}