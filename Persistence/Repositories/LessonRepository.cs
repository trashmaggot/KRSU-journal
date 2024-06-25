using Application.Repositories;
using Domain.Entities;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class LessonRepository : Repository<Lesson>, ILessonRepository
{
    public LessonRepository(Context context) : base(context)
    {
    }
}