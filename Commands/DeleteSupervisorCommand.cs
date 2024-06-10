using MediatR;

namespace ThesisManagementSystem.Commands
{
    public class DeleteSupervisorCommand : IRequest<int>
    {
        public int SupervisorId { get; set; }
    }
}
