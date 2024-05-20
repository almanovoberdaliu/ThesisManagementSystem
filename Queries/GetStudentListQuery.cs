using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {

    }
}
