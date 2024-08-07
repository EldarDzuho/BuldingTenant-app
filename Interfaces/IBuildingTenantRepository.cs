using api.Dtos.BuildingTenant;
using api.Models;

namespace api.Interfaces
{
    public interface IBuildingTenantRepository
    { 
        
        Task<List<BuildingTenant>> GetAllAsync();

        Task<BuildingTenant?> GetByIdAsync(int id);

        Task<BuildingTenant> CreateAsync(BuildingTenant buildingTenantModel);

        Task<BuildingTenant?> UpdateAsync(int id, UpdateBuildingTenantRequestDto buildingTenantDto);

        Task<BuildingTenant?> DeleteAsync(int id);
    }
}