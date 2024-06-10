using Microsoft.EntityFrameworkCore;
using ThesisManagementSystem.Data;
using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly DbContextClass _dbContext;

        public ModuleRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Module> AddModuleAsync(Module module)
        {
            var moduleDetails = new Module
            {
                Id = module.Id,
                Name = module.Name,
                Ects= module.Ects,
                SemesterID = module.SemesterID
            };

            var result = _dbContext.Modules.Add(moduleDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Module> GetModuleByIdAsync(int moduleId)
        {
            return await _dbContext.Modules.Where(x => x.Id == moduleId).FirstOrDefaultAsync();
        }

        public async Task<List<Module>> GetModuleListAsync()
        {
            return await _dbContext.Modules.ToListAsync();
        }
    }
}
