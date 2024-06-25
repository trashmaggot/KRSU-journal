using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseFeatures.Commands.CreateCourseCommand;

public class CreateCourseHandler : IRequestHandler<CreateCourseRequest, Unit>
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Unit> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        var course = new Course()
        {
            Name = request.Name,
            Hours = request.Hours
        };
        
        await _courseRepository.CreateAsync(course, cancellationToken);

        return Unit.Value;
    }
}

public class CreateCourseRequest : IRequest<Unit>
{
    public string Name { get; set; }
    public int    Hours { get; set; }
}

