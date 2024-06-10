using MediatR;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellation)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(request.StudentId);
            if (studentDetails == null)
            {
                return default;
            }

            studentDetails.StudentId = request.StudentId;
            studentDetails.StudentName = request.StudentName;
            studentDetails.StudentSurname = request.StudentSurname;
            studentDetails.StudentEmail = request.StudentEmail;
            studentDetails.YearOfRegistration = request.YearOfRegistration;
            studentDetails.ID = request.ID;
            studentDetails.SpecializationId = request.SpecializationId;
            studentDetails.ECTS= request.ECTS;
            studentDetails.HasUnfinishedExams= request.HasUnfinishedExams;
            studentDetails.UnfinishedExams = request.UnfinishedExams;
            studentDetails.SemesterId = request.SemesterId;

            return await _studentRepository.UpdateStudentAsync(studentDetails);
        }    
    }
}
