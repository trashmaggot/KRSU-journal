using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupFeatures.Commands.CreateGroupCommand;

public class CreateGroupHandler : IRequestHandler<CreateGroupRequest, Unit>
{
    private readonly IGroupRepository _groupRepository;

    public CreateGroupHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Unit> Handle(CreateGroupRequest request, CancellationToken cancellationToken)
    {
        var group = new Group()
        {
            Name = request.Name
        };

        await _groupRepository.CreateAsync(group, cancellationToken);
        
        return Unit.Value;
    }
}

public class CreateGroupRequest : IRequest<Unit>
{
    public string Name { get; set; }
}

