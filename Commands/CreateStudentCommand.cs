using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Commands
{
    public class CreateStudentCommand : IRequest<StudentDetailsDto>
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentEmail { get; set; }
        public int YearOfRegistration { get; set; }
        public int ID { get; set; }
        public int SpecializationId { get; set; }
        public int ECTS { get; set; }
        public bool HasUnfinishedExams { get; set; }
        public string? UnfinishedExams { get; set; }
        public int SemesterId { get; set; }
        public CreateStudentCommand(int studentId, string studentName, string studentSurname, string studentEmail,int yearOfRegistration, int fileId, int specializationId, int ects, bool hasUnfinishedExams, string unfinishedExams, int semesterId)
        {
            StudentId = studentId;
            StudentName = studentName;
            StudentSurname = studentSurname;
            StudentEmail = studentEmail;
            YearOfRegistration = yearOfRegistration;
            ID = fileId;
            SpecializationId = specializationId;
            ECTS = ects;
            HasUnfinishedExams = hasUnfinishedExams;
            UnfinishedExams = unfinishedExams;
            SemesterId = semesterId;
        }
    }


}
