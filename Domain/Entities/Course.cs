using Domain.Common;

namespace Domain.Entities;

public class Course : BaseEntity
{
    public string Name  { get; set; }
    public int    Hours { get; set; }

    public List<Group> Groups { get; set; } = new();
}