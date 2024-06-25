using Domain.Common;

namespace Domain.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }

    public List<Course>  Courses  { get; set; }
    public List<Lesson>  Lessons  { get; set; }
    public List<Student> Students { get; set; }
}