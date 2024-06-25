using Application.Repositories;
using Domain.Entities;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
{
    public AttendanceRepository(Context context) : base(context)
    {
    }
}