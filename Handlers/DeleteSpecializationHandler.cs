using MediatR;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class DeleteSpecializationHandler : IRequestHandler<DeleteSpecializationByIdCommand, int>
    {
        private readonly ISpecializationRepository specializationRepository;

        public DeleteSpecializationHandler(ISpecializationRepository specializationRepository)
        {
            this.specializationRepository = specializationRepository;
        }

        public async Task<int> Handle(DeleteSpecializationByIdCommand request, CancellationToken cancellationToken)
        {
            var specializationDetails = await specializationRepository.GetSpecializationByIdAsync(request.Id);
            if (specializationDetails == null)
            {
                return default;
            }

            return await specializationRepository.DeleteSpecializationAsync(specializationDetails.Id);
        }
    }
}
