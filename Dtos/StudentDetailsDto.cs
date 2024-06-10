namespace ThesisManagementSystem.Dtos
{
    public class StudentDetailsDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentEmail { get; set; }
        public int YearOfRegistration { get; set; }
        public int FileId { get; set; }
        public int SpecializationId { get; set; }
        public int ECTS { get; set; }
        public bool HasUnfinishedExams { get; set; }
        public string? UnfinishedExams { get; set; }
        public int SemesterId { get; set; }
    }
}
