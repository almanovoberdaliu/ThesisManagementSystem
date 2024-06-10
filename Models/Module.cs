using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisManagementSystem.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ects { get; set; }

        [ForeignKey("Semester")]
        public int SemesterID { get; set; }
        public Semester Semester { get; set; }
    }
}
