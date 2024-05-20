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
                ID = studentDetailsDto.FileId 
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
                FileId = result.Entity.ID
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
    }
}
