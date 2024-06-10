using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;

namespace ThesisManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController :ControllerBase
    {
        private readonly IMediator mediator;

        public ModuleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Module>> GetModuleListAsync()
        {
            var moduleDetails = await mediator.Send(new GetModuleListQuery());

            return moduleDetails;
        }


        [HttpGet("moduleId")]
        public async Task<Module> GetModuleByIdAsync(int moduleId)
        {
            var moduleDetails = await mediator.Send(new GetModuleByIdQuery() { Id = moduleId });

            return moduleDetails;
        }

        [HttpPost]
        public async Task<Module> AddModuleAsync(Module moduleDetails)
        {

            var moduleDetail = await mediator.Send(new CreateModuleCommand(
                moduleDetails.Id,
                moduleDetails.Name,
                moduleDetails.Ects,
                moduleDetails.SemesterID));
            return moduleDetail;
        }

    }
}
