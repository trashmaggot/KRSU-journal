using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CourseFeatures.Queries.GetCoursesQuery;

public class GetCoursesHandler : IRequestHandler<GetCoursesRequest, List<GetCoursesResponse>>
{
    private readonly ICourseRepository _courseRepository;

    public GetCoursesHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public Task<List<GetCoursesResponse>> Handle(GetCoursesRequest request, CancellationToken cancellationToken)
    {
        return _courseRepository.GetAll().Include(x => x.Groups).Select(x => new GetCoursesResponse
        {
            Id = x.Id,
            Name = x.Name,
            Groups = x.Groups.Select(y => new GetCoursesResponse.GroupDto()
            {
                Name = y.Name,
                Id = y.Id
            }).ToList()
        }).ToListAsync(cancellationToken);
    }
}

public class GetCoursesRequest : IRequest<List<GetCoursesResponse>>
{
    
}

public class GetCoursesResponse
{
    public Guid   Id { get; set; }
    public string Name { get; set; }
    public List<GroupDto> Groups { get; set; }
    
    public class GroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}