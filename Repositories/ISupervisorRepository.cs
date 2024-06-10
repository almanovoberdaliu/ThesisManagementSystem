using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public interface ISupervisorRepository
    {
        public Task<List<Supervisor>> GetSupervisorListAsync();
        public Task<Supervisor> GetSupervisorByIdAsync(int supervisorId);
        public Task<SupervisorDto> AddSupervisorAsync(SupervisorDto supervisor);
        public Task<int> UpdateSupervisorAsync(Supervisor supervisor);
        public Task<int> DeleteSupervisorAsync(int supervisorId);
    }
}
