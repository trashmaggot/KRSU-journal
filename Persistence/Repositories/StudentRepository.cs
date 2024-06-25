using Application.Repositories;
using Domain.Entities;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(Context context) : base(context)
    {
    }
}