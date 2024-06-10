using MediatR;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetailsDto>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetailsDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
          
            var studentDetails = new StudentDetailsDto()
            {
                StudentId = request.StudentId,
                StudentName = request.StudentName,
                StudentSurname= request.StudentSurname,
                StudentEmail= request.StudentEmail,
                YearOfRegistration = request.YearOfRegistration,
                FileId = request.ID,
                SpecializationId = request.SpecializationId,
                ECTS = request.ECTS,
                HasUnfinishedExams= request.HasUnfinishedExams,
                UnfinishedExams= request.HasUnfinishedExams ? request.UnfinishedExams: null,
                SemesterId = request.SemesterId
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}
