using MediatR;

namespace ThesisManagementSystem.Commands
{
    public class UpdateSpecializationCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FieldName { get; set; }

        public UpdateSpecializationCommand(int id, string fieldName)
        {
            Id = id;
            FieldName = fieldName;
        }
    }
}
