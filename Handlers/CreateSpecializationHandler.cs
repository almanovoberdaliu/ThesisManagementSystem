using MediatR;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class CreateSpecializationHandler : IRequestHandler<CreateSpecializationCommand, Specialization>
    {
        private readonly ISpecializationRepository specializationRepository;

        public CreateSpecializationHandler(ISpecializationRepository specializationRepository)
        {
            this.specializationRepository = specializationRepository;
        }
        public async Task<Specialization> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specializationDetails = new Specialization
            {
                Id = request.Id,
                FieldName = request.FieldName
            };
            return await specializationRepository.AddSpecializationAsync(specializationDetails);
        }
    }
}
