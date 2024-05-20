using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<StudentDetails>> GetStudentListAsync();
        public Task<StudentDetails> GetStudentByIdAsync(int studentId);
        public Task<StudentDetailsDto> AddStudentAsync(StudentDetailsDto studentDetails);
        public Task<int> UpdateStudentAsync(StudentDetails studentDetails);
        public Task<int> DeleteStudentAsync(int studentId);
    }
}
