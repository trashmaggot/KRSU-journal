using Application.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.LessonFeatures.Commands.CreateLessonCommand;

public class CreateLessonHandler : IRequestHandler<CreateLessonRequest, Unit>
{
    private readonly ILessonRepository _lessonRepository;
    private readonly IStudentRepository _studentRepository;

    public CreateLessonHandler(ILessonRepository lessonRepository, IStudentRepository studentRepository)
    {
        _lessonRepository = lessonRepository;
        _studentRepository = studentRepository;
    }

    public async Task<Unit> Handle(CreateLessonRequest request, CancellationToken cancellationToken)
    {
        var lesson = new Lesson()
        {
            DateTime = request.DateTime,
            GroupId = request.GroupId,
            CourseId = request.CourseId
        };

        var isExists = _lessonRepository
            .Find(x => x.DateTime == request.DateTime && x.CourseId == request.CourseId && x.GroupId == request.GroupId)
            .Any();

        if (isExists) return Unit.Value;

        var students = await _studentRepository.Find(x => x.GroupId == request.GroupId).ToListAsync(cancellationToken);

        var attedances = students.Select(x => new Attendance()
        {
            IsAttend = false,
            StudentId = x.Id
        }).ToList();

        lesson.Attendances = attedances;
        
        await _lessonRepository.CreateAsync(lesson, cancellationToken);

        return Unit.Value;
    }
}

public class CreateLessonRequest : IRequest<Unit>
{
    public DateTime DateTime { get; set; }
    public Guid GroupId      { get; set; }
    public Guid CourseId     { get; set; }
}
