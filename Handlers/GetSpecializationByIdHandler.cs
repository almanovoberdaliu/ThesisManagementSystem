using MediatR;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetSpecializationByIdHandler : IRequestHandler<GetSpecializationByIdQuery, Specialization>
    {
        private ISpecializationRepository specializationRepository;

        public GetSpecializationByIdHandler(ISpecializationRepository specializationRepository)
        {
            this.specializationRepository = specializationRepository;
        }

        public async Task<Specialization> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
        {
            return await specializationRepository.GetSpecializationByIdAsync(request.Id);
        }
    }
}
