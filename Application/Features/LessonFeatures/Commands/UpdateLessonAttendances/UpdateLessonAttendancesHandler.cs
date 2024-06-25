using Application.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.LessonFeatures.Commands.UpdateLessonAttendances;

public class UpdateLessonAttendancesHandler : IRequestHandler<UpdateLessonAttendancesRequest, Unit>
{
    private readonly IAttendanceRepository _attendanceRepository;

    public UpdateLessonAttendancesHandler(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task<Unit> Handle(UpdateLessonAttendancesRequest request, CancellationToken cancellationToken)
    {
        var attendances = await _attendanceRepository
            .Find(a => request.Attendances.Select(x => x.Id).Contains(a.Id))
            .ToListAsync(cancellationToken);
        
        attendances.ForEach(a =>
        {
            var dto = request.Attendances.Find(x => x.Id == a.Id);
            
            if (dto is not null) a.IsAttend = dto.IsAttend;
        });

        await _attendanceRepository.UpdateRangeAsync(attendances);
        
        return Unit.Value;
    }
}

public class UpdateLessonAttendancesRequest : IRequest<Unit>
{
    public List<UpdateLessonAttendancesDto> Attendances { get; set; }

    public class UpdateLessonAttendancesDto
    {
        public Guid Id { get; set; }
        public bool IsAttend { get; set; }
    }
    
}