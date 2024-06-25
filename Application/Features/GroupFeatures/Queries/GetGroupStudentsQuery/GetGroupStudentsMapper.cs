using AutoMapper;
using Domain.Entities;

namespace Application.Features.GroupFeatures.Queries.GetGroupStudentsQuery;

public class GetGroupStudentsMapper : Profile
{
    public GetGroupStudentsMapper()
    {
        CreateMap<Student, GetGroupStudentsResponse>();
    }
}