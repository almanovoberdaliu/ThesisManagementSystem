using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;

namespace ThesisManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly IMediator mediator;

        public SupervisorController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<List<Supervisor>> GetSupervisorListAsync()
        {
            var supervisorDetails = await mediator.Send(new GetSupervisorListQuery());

            return supervisorDetails;
        }


        [HttpGet("supervisorId")]
        public async Task<Supervisor> GetSupervisorByIdAsync(int supervisorId)
        {
            var supervisorDetails = await mediator.Send(new GetSupervisorByIdQuery() { SupervisorId = supervisorId });

            return supervisorDetails;
        }

        [HttpPost]
        public async Task<SupervisorDto> AddSupervisorAsync(SupervisorDto supervisorDetails)
        {

            var supervisorDetail = await mediator.Send(new CreateSupervisorCommand(
                supervisorDetails.SupervisorId,
                supervisorDetails.Name,
                supervisorDetails.Surname,
                supervisorDetails.Email,
                supervisorDetails.Specializations,
                supervisorDetails.AvailabilityId));

            return supervisorDetail;
        }

        [HttpPut]
        public async Task<int> UpdateSupervisorAsync(Supervisor supervisorDetails)
        {
            var isSupervisorDetailUpdated = await mediator.Send(new UpdateSupervisorCommand(
               supervisorDetails.SupervisorId,
               supervisorDetails.Name,
               supervisorDetails.Surname,
               supervisorDetails.Email,
               supervisorDetails.Specializations,
               supervisorDetails.AvailabilityId));

            return isSupervisorDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteSupervisorAsync(int Id)
        {
            return await mediator.Send(new DeleteSupervisorCommand() { SupervisorId = Id });
        }

    }

}
