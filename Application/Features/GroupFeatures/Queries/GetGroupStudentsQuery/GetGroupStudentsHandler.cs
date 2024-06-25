using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GroupFeatures.Queries.GetGroupStudentsQuery;

public class GetGroupStudentsHandler : IRequestHandler<GetGroupStudentsRequest, List<GetGroupStudentsResponse>>
{
    private readonly IStudentRepository _studentRepository;


    public GetGroupStudentsHandler(IStudentRepository repository)
    {
        _studentRepository = repository;
    }

    public async Task<List<GetGroupStudentsResponse>> Handle(GetGroupStudentsRequest request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.Find(x => x.GroupId == request.GroupId)
            .Select(x => new GetGroupStudentsResponse()
            {
                GroupId = x.GroupId,
                StudentId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName
            })
            .ToListAsync(cancellationToken);
        return students;
    }
}