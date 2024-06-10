using MediatR;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetModuleListHandler : IRequestHandler<GetModuleListQuery, List<Module>>
    {
        private readonly IModuleRepository moduleRepository;

        public GetModuleListHandler(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }

        public async Task<List<Module>> Handle(GetModuleListQuery request, CancellationToken cancellationToken)
        {
            return await moduleRepository.GetModuleListAsync();
        }
    }
}
