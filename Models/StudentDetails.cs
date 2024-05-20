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

        [ForeignKey("FileDetails")]
        public int ID { get; set; }
        public FileDetails FileDetails { get; set; }

    }

}   

