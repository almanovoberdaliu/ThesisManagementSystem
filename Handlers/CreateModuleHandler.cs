using MediatR;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Handlers
{
    public class CreateModuleHandler : IRequestHandler<CreateModuleCommand, Module>
    {
        private readonly IModuleRepository moduleRepository;

        public CreateModuleHandler(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }

        public async Task<Module> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            var moduleDetails = new Module
            {
                Id = request.Id,
                Name = request.Name,
                Ects= request.Ects,
                SemesterID= request.SemesterID
            };
            return await moduleRepository.AddModuleAsync(moduleDetails);
        }
    }
}
