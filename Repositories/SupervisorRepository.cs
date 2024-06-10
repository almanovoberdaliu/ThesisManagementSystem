using Microsoft.EntityFrameworkCore;
using ThesisManagementSystem.Data;
using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly DbContextClass _dbContext;
        public SupervisorRepository(DbContextClass dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task<SupervisorDto> AddSupervisorAsync(SupervisorDto supervisor)
        {
            var supervisorDetails = new Supervisor
            {
                SupervisorId = supervisor.SupervisorId,
                Name = supervisor.Name,
                Surname = supervisor.Surname,
                Email = supervisor.Email,
                Specializations = supervisor.Specializations,
                AvailabilityId = supervisor.AvailabilityId
            };

            var result = _dbContext.Supervisors.Add(supervisorDetails);
            await _dbContext.SaveChangesAsync();

            // Map the result.Entity to StudentDetailsDto before returning
            return new SupervisorDto
            {
                SupervisorId = result.Entity.SupervisorId,
                Name= result.Entity.Name,
                Surname= result.Entity.Surname,
                Email= result.Entity.Email,
                Specializations = result.Entity.Specializations,
                AvailabilityId = result.Entity.AvailabilityId
               
            };
        }

        public async Task<int> DeleteSupervisorAsync(int supervisorId)
        {
            var filteredData = _dbContext.Supervisors.Where(x => x.SupervisorId == supervisorId).FirstOrDefault();
            _dbContext.Supervisors.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Supervisor> GetSupervisorByIdAsync(int supervisorId)
        {
            return await _dbContext.Supervisors.Where(x => x.SupervisorId == supervisorId).FirstOrDefaultAsync();
        }

        public async Task<List<Supervisor>> GetSupervisorListAsync()
        {
            return await _dbContext.Supervisors.ToListAsync();
        }

        public async Task<int> UpdateSupervisorAsync(Supervisor supervisor)
        {
            _dbContext.Supervisors.Update(supervisor);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
