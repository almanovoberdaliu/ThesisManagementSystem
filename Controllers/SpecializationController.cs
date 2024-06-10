using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Queries;

namespace ThesisManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly IMediator mediator;

        public SpecializationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Specialization>> GetSpecializationListAsync()
        {
            var specializationDetails = await mediator.Send(new GetSpecializationListQuery());

            return specializationDetails;
        }

        [HttpGet("specializationId")]
        public async Task<Specialization> GetSpecializationByIdAsync(int specializationId)
        {
            var specializationDetails = await mediator.Send(new GetSpecializationByIdQuery() { Id = specializationId });

            return specializationDetails;
        }

        [HttpPost]
        public async Task<Specialization> AddSpecializationAsync(Specialization specializationDetails)
        {

            var specializatioDetail = await mediator.Send(new CreateSpecializationCommand(
                specializationDetails.Id,
                specializationDetails.FieldName));
            return specializatioDetail;
        }

        [HttpPut]
        public async Task<int> UpdateSpecializatioAsync(Specialization specializationDetails)
        {
            var isSpecializationDetailUpdated = await mediator.Send(new UpdateSpecializationCommand(
               specializationDetails.Id,
               specializationDetails.FieldName));
            return isSpecializationDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteSpecializationAsync(int Id)
        {
            return await mediator.Send(new DeleteSpecializationByIdCommand() { Id = Id });
        }

    }

}