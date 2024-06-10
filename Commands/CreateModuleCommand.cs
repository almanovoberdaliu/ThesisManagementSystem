using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Commands
{
    public class CreateModuleCommand : IRequest<Module>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ects { get; set; }
        public int SemesterID { get; set; }

        public CreateModuleCommand(int id, string name, int ects, int semesterID)
        {
            Id = id;
            Name = name;
            Ects = ects;
            SemesterID = semesterID;
        }
    }
}
