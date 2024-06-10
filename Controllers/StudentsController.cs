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
                studentDetails.FileId,
                studentDetails.SpecializationId,
                studentDetails.ECTS,
                studentDetails.HasUnfinishedExams,
                studentDetails.UnfinishedExams,
                studentDetails.SemesterId));

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
               studentDetails.ID,
               studentDetails.SpecializationId,
               studentDetails.ECTS,
               studentDetails.HasUnfinishedExams,
               studentDetails.UnfinishedExams,
               studentDetails.SemesterId));

            return isStudentDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int Id)
        {
            return await mediator.Send(new DeleteStudentCommand() { StudentId = Id });
        }

        [HttpGet("expiration-of-studies/{studentId}")]
        public async Task<IActionResult> GetExpirationOfStudies(int studentId)
        {
            var result = await mediator.Send(new GetYearOfStudiesQuery { StudentId = studentId });
            return Ok(result);
        }


        [HttpGet("get-ects/{studentId}")]
        public async Task<IActionResult> GetEcts(int studentId)
        {
            var result = await mediator.Send(new GetECTSQuery { StudentId = studentId });
            return Ok(result);
        }

        [HttpGet("get-semester-of-unfinished-exams/{studentId}")]
        public async Task<IActionResult> GetSemesterOfUnfinishedExams(int studentId)
        {
            var result = await mediator.Send(new GetSemesterOfUnfinishedExamsQuery { StudentId = studentId });
            return Ok(result);
        }

        [HttpGet("get-modules-by-semesterId/{semesterId}")]
        public async Task<IActionResult> GetModulesBySemester(int semesterId)
        {
            var result = await mediator.Send(new GetModulesBySemesterQuery { SemesterID = semesterId });
            return Ok(result);
        }

        [HttpGet("has-met-the-criteria/{studentId}")]
        public async Task<IActionResult> HasMetTheCriteria(int studentId)
        {
            var result = await mediator.Send(new HasMetTheCriteriaQuery { StudentId = studentId });
            return Ok(result);
        }


    }

}
