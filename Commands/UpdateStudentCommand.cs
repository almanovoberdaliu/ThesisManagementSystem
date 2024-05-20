using MediatR;

namespace ThesisManagementSystem.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentEmail { get; set; }
        public int YearOfRegistration { get; set; }
        public int ID { get; set; }

        public UpdateStudentCommand(int studentId, string studentName, string studentSurname, string studentEmail, int yearOfRegistration, int fileId)
        {
            StudentId = studentId;
            StudentName = studentName;
            StudentSurname = studentSurname;
            StudentEmail = studentEmail;
            YearOfRegistration = yearOfRegistration;
            ID = fileId;
        }
    }
}
