using Domain.Common;

namespace Domain.Entities;

public class Lesson : BaseEntity
{
    public DateTime DateTime { get; set; }
    public Guid     GroupId  { get; set; }
    public Guid     CourseId { get; set; }
    
    public Group  Group { get; set; }
    public Course Course { get; set; }
    
    public List<Attendance> Attendances { get; set; }
}
