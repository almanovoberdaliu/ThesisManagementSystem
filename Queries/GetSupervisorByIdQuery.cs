using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Queries
{
    public class GetSupervisorByIdQuery : IRequest<Supervisor>
    {
        public int SupervisorId { get; set; }
    }
}
