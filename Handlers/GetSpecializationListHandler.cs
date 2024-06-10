using MediatR;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetSpecializationListHandler: IRequestHandler<GetSpecializationListQuery,List<Specialization>>
    {
        private readonly ISpecializationRepository specializationRepository;

        public GetSpecializationListHandler(ISpecializationRepository specializationRepository)
        {
            this.specializationRepository = specializationRepository;
        }

        public async Task<List<Specialization>> Handle(GetSpecializationListQuery request, CancellationToken cancellationToken)
        {
            return await specializationRepository.GetSpecializationsAsync();
        }
    }
}
