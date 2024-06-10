using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Queries
{
    public class GetModuleListQuery : IRequest<List<Module>>
    {

    }
}
