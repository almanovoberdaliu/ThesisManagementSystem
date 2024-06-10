using MediatR;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class HasMetTheCriteriaHandler : IRequestHandler<HasMetTheCriteriaQuery, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public HasMetTheCriteriaHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(HasMetTheCriteriaQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.HasMetTheCriteriaAsync(request.StudentId);
        }
    }
}
