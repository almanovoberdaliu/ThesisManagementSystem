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
    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            var studentDetails = await mediator.Send(new GetStudentListQuery());

            return studentDetails;
        }

        [HttpGet("studentId")]
        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            var studentDetails = await mediator.Send(new GetStudentByIdQuery() { StudentId = studentId });

            return studentDetails;
        }

        [HttpPost]
        public async Task<StudentDetailsDto> AddStudentAsync(StudentDetailsDto studentDetails)
        {
         
            var studentDetail = await mediator.Send(new CreateStudentCommand(
                studentDetails.StudentId,
                studentDetails.StudentName,
                studentDetails.StudentSurname,
                studentDetails.StudentEmail,
                studentDetails.YearOfRegistration,
                studentDetails.FileId));
            return studentDetail;
        }

        [HttpPut]
        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            var isStudentDetailUpdated = await mediator.Send(new UpdateStudentCommand(
               studentDetails.StudentId,
               studentDetails.StudentName,
               studentDetails.StudentSurname,
               studentDetails.StudentEmail,
               studentDetails.YearOfRegistration,
               studentDetails.ID));
            return isStudentDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int Id)
        {
            return await mediator.Send(new DeleteStudentCommand() { StudentId = Id });
        }


    }

}
