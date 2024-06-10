using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Queries
{
    public class GetModulesBySemesterQuery: IRequest<List<Module>>
    {
        public int SemesterID { get; set; }
    }
}
