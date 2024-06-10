using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisManagementSystem.Models
{
    public class StudentDetails
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentEmail { get; set;}
        public int YearOfRegistration { get; set; }
        public int ECTS { get; set;}
        public bool HasUnfinishedExams { get; set; }
        public string? UnfinishedExams { get; set; }

        [ForeignKey("FileDetails")]
        public int ID { get; set; }
        public FileDetails FileDetails { get; set; }

        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        [ForeignKey("Semester")]
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
    }

}   

