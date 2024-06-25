using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CourseFeatures.Commands.AddGroupForCourse;

public class AddGroupForCourseHandler : IRequestHandler<AddGroupForCourseCommand, Unit>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IGroupRepository _groupRepository;

    public AddGroupForCourseHandler(ICourseRepository courseRepository, IGroupRepository groupRepository)
    {
        _courseRepository = courseRepository;
        _groupRepository = groupRepository;
    }

    public async Task<Unit> Handle(AddGroupForCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.Find(x => x.Id == request.CourseId)
            .Include(x => x.Groups)
            .FirstOrDefaultAsync(cancellationToken);

        var group = await _groupRepository
            .Find(x => x.Id == request.GroupId)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (course is null || group is null) return Unit.Value;
        
        course.Groups.Add(group);

        await _courseRepository.UpdateAsync(course, cancellationToken);

        return Unit.Value;
    }
}

public class AddGroupForCourseCommand : IRequest<Unit>
{
    public Guid CourseId { get; set; }
    public Guid GroupId { get; set; }
    
}
