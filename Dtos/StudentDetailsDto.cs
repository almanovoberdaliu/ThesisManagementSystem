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
    }
}
