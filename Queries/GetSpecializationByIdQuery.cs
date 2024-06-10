using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Queries
{
    public class GetSpecializationByIdQuery : IRequest<Specialization>
    {
        public int Id { get; set; }
    }
}
