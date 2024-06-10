using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public interface ISpecializationRepository
    {
        public Task<List<Specialization>> GetSpecializationsAsync();
        public Task<Specialization> GetSpecializationByIdAsync(int Id);
        public Task<Specialization> AddSpecializationAsync(Specialization specialization);
        public Task<int> UpdateSpecializationAsync(Specialization specialization);
        public Task<int> DeleteSpecializationAsync(int specialization);
    }
}
