using MediatR;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class UpdateSpecializationHandler : IRequestHandler<UpdateSpecializationCommand, int>
    {
        private readonly ISpecializationRepository specializationRepository;

        public UpdateSpecializationHandler(ISpecializationRepository specializationRepository)
        {
            this.specializationRepository = specializationRepository;
        }

        public async Task<int> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specializationDetails = await specializationRepository.GetSpecializationByIdAsync(request.Id);
            if (specializationDetails == null)
            {
                return default;
            }

            specializationDetails.Id = request.Id;
            specializationDetails.FieldName = request.FieldName;
      

            return await specializationRepository.UpdateSpecializationAsync(specializationDetails);
        }
    }
}
