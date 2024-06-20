using Microsoft.EntityFrameworkCore;
using ThesisManagementSystem.Data;
using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextClass _dbContext;

        public StudentRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StudentDetailsDto> AddStudentAsync(StudentDetailsDto studentDetailsDto)
        {
            var studentDetails = new StudentDetails
            {
                StudentId = studentDetailsDto.StudentId,
                StudentName = studentDetailsDto.StudentName,
                StudentSurname = studentDetailsDto.StudentSurname,
                StudentEmail = studentDetailsDto.StudentEmail,
                YearOfRegistration = studentDetailsDto.YearOfRegistration,
                ID = studentDetailsDto.FileId,
                SpecializationId = studentDetailsDto.SpecializationId,
                ECTS= studentDetailsDto.ECTS,
                HasUnfinishedExams = studentDetailsDto.HasUnfinishedExams,
                UnfinishedExams = studentDetailsDto.HasUnfinishedExams ? studentDetailsDto.UnfinishedExams : null,
                SemesterId =studentDetailsDto.SemesterId
            };

            var result = _dbContext.Students.Add(studentDetails);
            await _dbContext.SaveChangesAsync();

            // Map the result.Entity to StudentDetailsDto before returning
            return new StudentDetailsDto
            {
                StudentId = result.Entity.StudentId,
                StudentName = result.Entity.StudentName,
                StudentSurname = result.Entity.StudentSurname,
                StudentEmail = result.Entity.StudentEmail,
                YearOfRegistration = result.Entity.YearOfRegistration,
                FileId = result.Entity.ID,
                SpecializationId = result.Entity.SpecializationId,
                ECTS = result.Entity.ECTS,
                HasUnfinishedExams = result.Entity.HasUnfinishedExams,
                UnfinishedExams = result.Entity.UnfinishedExams,
                SemesterId = result.Entity.SemesterId
            };
        }

        public async Task<int> DeleteStudentAsync(int studentId)
        {
            var filteredData = _dbContext.Students.Where(x => x.StudentId == studentId).FirstOrDefault();
            _dbContext.Students.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            return await _dbContext.Students.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            _dbContext.Students.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetYearOfStudies(int studentId)
        {
            var student = await _dbContext.Students.FindAsync(studentId);
            return student == null ? 0 : DateTime.Now.Year - student.YearOfRegistration;
        }
        
        public async Task<string> ExpirationOfStudies(int studentId)
        {
            var yearsOfStudy = await GetYearOfStudies(studentId);
            return yearsOfStudy >= 6 ? "The student's studies have expired!!!." : "The student's studies are still valid.";
        }

        // metod qe na duhet per metoden MetAllCriteria 
        public async Task<bool> GetEcts(int studentId)
        {
            var student = await _dbContext.Students.FindAsync(studentId);
            return student?.ECTS >= 158;
        }

        // metod qe na duhet per metoden MetAllCriteria 
        public async Task<bool> GetSemesterOfUnfinishedExams(int studentId)
        {
            var student = await _dbContext.Students.FindAsync(studentId);
            return student?.SemesterId >= 4;
        }

        // metod qe na duhet me i listu modulet ne baze te semestrit qe perzgjedh studeti(dropdown list ne front)
        public async Task<List<Module>> GetModulesBySemesterAsync(int semesterId)
        {
            return await _dbContext.Modules.Where(m => m.SemesterID == semesterId).ToListAsync();
        }


        // met all the criteria
        // ne front: e kqyr a eshte e sakte, nese po e  bon enable butonin per next, nese jo e bon disable edhe e shfaq
        //ni mesazh njoftus
        public async Task<bool> HasMetTheCriteriaAsync(int studentId)
        {
            return await GetEcts(studentId) && await GetSemesterOfUnfinishedExams(studentId);
        }
    }
}
