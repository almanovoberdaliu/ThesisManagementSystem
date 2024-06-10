using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ThesisManagementSystem.Data;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly DbContextClass _dbContext;
        public SpecializationRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Specialization> AddSpecializationAsync(Specialization specialization)
        {
            var specializationDetails = new Specialization
            {
                Id = specialization.Id,
                FieldName = specialization.FieldName
            };

            var result = _dbContext.Specializations.Add(specializationDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteSpecializationAsync(int specialization)
        {
            var filteredData = _dbContext.Specializations.Where(x => x.Id == specialization).FirstOrDefault();
            _dbContext.Specializations.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Specialization> GetSpecializationByIdAsync(int Id)
        {
            return await _dbContext.Specializations.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Specialization>> GetSpecializationsAsync()
        {
            return await _dbContext.Specializations.ToListAsync();
        }

        public async Task<int> UpdateSpecializationAsync(Specialization specialization)
        {
            _dbContext.Specializations.Update(specialization);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
