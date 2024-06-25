using Domain.Common;

namespace Domain.Entities;

public class Attendance : BaseEntity
{
    public Guid     StudentId { get; set; }
    public Guid     LessonId  { get; set; }
    public bool     IsAttend  { get; set; }

    public Student  Student   { get; set; }
    public Lesson   Lesson    { get; set; }
}