using ThesisManagementSystem.Dtos;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public interface IModuleRepository
    {
        public Task<List<Module>> GetModuleListAsync();
        public Task<Module> GetModuleByIdAsync(int moduleId);
        public Task<Module> AddModuleAsync(Module module);
    }
}
