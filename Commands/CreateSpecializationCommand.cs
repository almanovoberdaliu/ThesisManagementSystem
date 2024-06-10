using MediatR;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Commands
{
    public class CreateSpecializationCommand : IRequest<Specialization>
    {
        public int Id { get; set; }
        public string FieldName { get; set; }

        public CreateSpecializationCommand(int id, string fieldName)
        {
            Id = id;
            FieldName = fieldName;
        }
    }

}
