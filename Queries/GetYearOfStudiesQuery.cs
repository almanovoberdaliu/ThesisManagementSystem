using MediatR;

namespace ThesisManagementSystem.Queries
{
    public class GetYearOfStudiesQuery:IRequest<int>
    { 
            public int StudentId { get; set; }
        
    }
}
