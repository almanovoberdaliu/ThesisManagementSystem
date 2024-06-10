using MediatR;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class GetModuleByIdHandler : IRequestHandler<GetModuleByIdQuery, Module>
    {
        private readonly IModuleRepository _moduleRepository;
        public GetModuleByIdHandler(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<Module> Handle(GetModuleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _moduleRepository.GetModuleByIdAsync(request.Id);
        }
    }
}
