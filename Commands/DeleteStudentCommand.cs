using MediatR;

namespace ThesisManagementSystem.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int StudentId { get; set; }
    }
}
