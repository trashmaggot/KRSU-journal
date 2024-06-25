using Domain.Common;

namespace Domain.Entities;

public class Student : BaseEntity
{
    public string FirstName  { get; set; }
    public string MiddleName { get; set; }
    public string LastName   { get; set; }
    public Guid   GroupId    { get; set; }
    
    public Group            Group       { get; set; }
    public List<Attendance> Attendances { get; set; }
}