using MediatR;

namespace ThesisManagementSystem.Queries
{
    public class GetECTSQuery : IRequest<bool>
    {
        public int StudentId { get; set; }

    }
}
