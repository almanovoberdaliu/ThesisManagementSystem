using MediatR;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetModulesBySemesterHandler : IRequestHandler<GetModulesBySemesterQuery, List<Module>>
    {
        private readonly IStudentRepository studentRepository;

        public GetModulesBySemesterHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<List<Module>> Handle(GetModulesBySemesterQuery request, CancellationToken cancellationToken)
        {
            return await studentRepository.GetModulesBySemesterAsync(request.SemesterID);
        }
    }
}
