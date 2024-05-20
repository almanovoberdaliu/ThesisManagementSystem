using MediatR;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentByIdAsync(request.StudentId);
        }
    }
}
