using MediatR;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetECTSHandler : IRequestHandler<GetECTSQuery, bool>
    {
        private readonly IStudentRepository _studentRepository;
        public GetECTSHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(GetECTSQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetEcts(request.StudentId);
        }
    }
}
