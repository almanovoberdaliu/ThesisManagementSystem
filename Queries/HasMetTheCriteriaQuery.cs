using MediatR;

namespace ThesisManagementSystem.Queries
{
    public class HasMetTheCriteriaQuery:IRequest<bool>
    {
        public int StudentId { get; set; }
    }
}
