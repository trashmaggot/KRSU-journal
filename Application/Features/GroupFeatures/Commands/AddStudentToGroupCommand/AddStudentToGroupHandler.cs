using Application.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GroupFeatures.Commands.AddStudentToGroupCommand;

public class AddStudentToGroupHandler : IRequestHandler<AddStudentToGroupRequest, Unit>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILessonRepository _lessonRepository;
    private readonly IAttendanceRepository _attendanceRepository;

    public AddStudentToGroupHandler(
        IStudentRepository studentRepository, 
        ILessonRepository lessonRepository, 
        IAttendanceRepository attendanceRepository)
    {
        _studentRepository = studentRepository;
        _lessonRepository = lessonRepository;
        _attendanceRepository = attendanceRepository;
    }

    public async Task<Unit> Handle(AddStudentToGroupRequest request, CancellationToken cancellationToken)
    {
        var student = new Student()
        {
            GroupId = request.GroupId,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName
        };
        
        await _studentRepository.CreateAsync(student, cancellationToken);
        
        var lessons = await _lessonRepository
            .Find(x => x.GroupId == request.GroupId)
            .ToListAsync(cancellationToken);

        var attendances = new List<Attendance>(lessons.Count);

        foreach (var lesson in lessons)
        {
            var attendance = new Attendance()
            {
                IsAttend = false,
                StudentId = student.Id,
                LessonId = lesson.Id
            };
            attendances.Add(attendance);
        }

        await _attendanceRepository.AddRangeAsync(attendances, cancellationToken);

        return Unit.Value;
    }
}

public class AddStudentToGroupRequest : IRequest<Unit>
{
    public Guid GroupId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}

