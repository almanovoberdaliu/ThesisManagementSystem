using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Commands
{
    public class CreateSemesterCommand : IRequest<Semester>
    {
        public int Id { get; set; }

        public CreateSemesterCommand(int id)
        {
            Id = id;
        }
    }
   
}
