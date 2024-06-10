using MediatR;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class CreateSemesterHandler : IRequestHandler<CreateSemesterCommand, Semester>
    {
        private readonly ISemesterRepository semesterRepository;

        public CreateSemesterHandler(ISemesterRepository semesterRepository)
        {
            this.semesterRepository = semesterRepository;
        }

        public async Task<Semester> Handle(CreateSemesterCommand request, CancellationToken cancellationToken)
        {
            var semesterDetails = new Semester
            {
                Id = request.Id,
               
            };
            return await semesterRepository.AddSemesterAsync(semesterDetails);
        }
    
    }
}
