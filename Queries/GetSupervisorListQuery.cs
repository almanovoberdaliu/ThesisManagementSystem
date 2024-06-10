using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Queries
{
    public class GetSupervisorListQuery : IRequest<List<Supervisor>>
    {
    }
}
