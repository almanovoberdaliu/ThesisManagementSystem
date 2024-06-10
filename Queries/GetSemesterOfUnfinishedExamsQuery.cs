using MediatR;

namespace ThesisManagementSystem.Queries
{
    public class GetSemesterOfUnfinishedExamsQuery :IRequest<bool>
    {
        public int StudentId { get; set; }

    }

}
