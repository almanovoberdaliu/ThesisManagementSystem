using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Queries
{
    public class GetModuleByIdQuery : IRequest<Module>
    {
        public int Id { get; set; }
    }
   
}
