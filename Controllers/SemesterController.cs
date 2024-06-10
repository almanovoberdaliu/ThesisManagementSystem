using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThesisManagementSystem.Commands;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly IMediator mediator;

        public SemesterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<Semester> AddSemesterAsync(Semester semester)
        {

            var semesterDetail = await mediator.Send(new CreateSemesterCommand(
                semester.Id));
            return semesterDetail;
        }

    }
}
