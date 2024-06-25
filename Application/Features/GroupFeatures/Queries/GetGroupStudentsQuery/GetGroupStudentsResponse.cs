namespace Application.Features.GroupFeatures.Queries.GetGroupStudentsQuery;

public class GetGroupStudentsResponse
{
    public Guid StudentId { get; set; }
    public Guid GroupId   { get; set; }
    
    public string FirstName  { get; set; }
    public string MiddleName { get; set; }
    public string LastName   { get; set; }
}