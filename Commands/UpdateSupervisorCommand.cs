using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Commands
{
    public class UpdateSupervisorCommand : IRequest<int>
    {
        public int SupervisorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Specializations { get; set; }
        public int AvailabilityId { get; set; }
        public UpdateSupervisorCommand(int supervisorId, string name, string surname, string email, string specializations, int availabilityid)
        {
            SupervisorId = supervisorId;
            Name = name;
            Surname = surname;
            Email = email;
            Specializations = specializations;
            AvailabilityId = availabilityid;
        }
    }
}
