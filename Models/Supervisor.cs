using Microsoft.Extensions.Hosting;

namespace ThesisManagementSystem.Models
{
    public class Supervisor
    {
        public int SupervisorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Specializations { get; set; }

        public int AvailabilityId { get; set; }
        public Availability Availability { get; set; }
        public ICollection<StudentDetails> Students { get; } = new List<StudentDetails>();
        


    }
}
