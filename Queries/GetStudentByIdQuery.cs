using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int StudentId { get; set; }
    }
}
