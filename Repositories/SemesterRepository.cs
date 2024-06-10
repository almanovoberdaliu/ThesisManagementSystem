using ThesisManagementSystem.Data;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly DbContextClass _dbContext;

        public SemesterRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Semester> AddSemesterAsync(Semester semester)
        {
            var semesterDetails = new Semester
            {
                Id = semester.Id,
            };

            var result = _dbContext.Semesters.Add(semesterDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
