using MediatR;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetSemesterOfUnfinishedExamsHandler : IRequestHandler<GetSemesterOfUnfinishedExamsQuery, bool>
    {
        private readonly IStudentRepository _studentRepository;
        public GetSemesterOfUnfinishedExamsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(GetSemesterOfUnfinishedExamsQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetSemesterOfUnfinishedExams(request.StudentId);
        }
    }
    
    
}
