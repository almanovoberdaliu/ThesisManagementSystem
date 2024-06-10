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
        public Task<int> GetYearOfStudies(int studentId);
        public Task<string> ExpirationOfStudies(int studentId);
        public Task<bool> GetEcts(int studentId);
        public Task<bool> GetSemesterOfUnfinishedExams(int studentId);
        public Task<List<Module>> GetModulesBySemesterAsync(int semesterId);
        public Task<bool> HasMetTheCriteriaAsync(int studentId);
    }
}
