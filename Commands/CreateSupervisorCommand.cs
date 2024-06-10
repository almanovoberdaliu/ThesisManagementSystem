using MediatR;
using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Commands
{
    public class CreateSupervisorCommand : IRequest<SupervisorDto>
    {
        public int SupervisorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Specializations { get; set; }
        public int AvailabilityId { get; set; }

        public CreateSupervisorCommand(int supervisorId, string name, string surname,string email,string specializations,int availabilityid)
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
