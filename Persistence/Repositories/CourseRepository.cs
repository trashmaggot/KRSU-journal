using Application.Repositories;
using Domain.Entities;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(Context context) : base(context)
    {
    }
}