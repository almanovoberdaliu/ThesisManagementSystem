using MediatR;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetYearOfStudiesHandler : IRequestHandler<GetYearOfStudiesQuery, int>
    {
        private readonly IStudentRepository _studentRepository;
        public GetYearOfStudiesHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(GetYearOfStudiesQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetYearOfStudies(request.StudentId);
        }
    }
}
