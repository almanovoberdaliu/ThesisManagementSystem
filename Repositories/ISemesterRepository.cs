using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public interface ISemesterRepository
    {
        public Task<Semester> AddSemesterAsync(Semester semester);
    }
}
