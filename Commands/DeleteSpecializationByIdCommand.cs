using MediatR;

namespace ThesisManagementSystem.Commands
{
    public class DeleteSpecializationByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
