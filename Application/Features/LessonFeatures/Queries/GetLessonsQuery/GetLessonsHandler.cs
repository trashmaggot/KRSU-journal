using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.LessonFeatures.Queries.GetLessonsQuery;

public class GetLessonsHandler : IRequestHandler<GetLessonsRequest, List<GetLessonsResponse>>
{
    private readonly ILessonRepository _lessonRepository;

    public GetLessonsHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<List<GetLessonsResponse>> Handle(GetLessonsRequest request, CancellationToken cancellationToken)
    {
        
        var lessons = await _lessonRepository
            .Find(x => x.CourseId == request.CourseId && x.GroupId == request.GroupId)
            .Skip((request.Page - 1) * request.Size).Take(request.Size)
            .Include(x => x.Attendances)
            .Select(x => new GetLessonsResponse
            {
                LessonId = x.Id,
                DateTime = x.DateTime,
                Attedances = x.Attendances.Select(y =>
                    new GetLessonsResponse.AttedanceDto()
                    {
                        Id = y.Id,
                        StudentId = y.StudentId,
                        LessonId = y.LessonId,
                        IsAttend = y.IsAttend
                }).ToList()
            }).ToListAsync(cancellationToken);

        return lessons;
    }
}

public class GetLessonsRequest : IRequest<List<GetLessonsResponse>>
{
    public Guid CourseId { get; set; }
    public Guid GroupId { get; set; }
    public int Size { get; set; }
    public int Page { get; set; }
}

public class GetLessonsResponse
{
    public Guid LessonId { get; set; }
    public DateTime DateTime { get; set; }
    public List<AttedanceDto> Attedances { get; set; }

    public class AttedanceDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid LessonId { get; set; }
        public bool IsAttend { get; set; }
    }

}