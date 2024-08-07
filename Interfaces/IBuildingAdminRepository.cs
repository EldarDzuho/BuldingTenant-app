using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BuildingAdmin;
using api.Models;

namespace api.Interfaces
{
    public interface IBuildingAdminRepository
    { 
        Task<List<BuildingAdmin>> GetAllAsync();
        Task<BuildingAdmin?> GetByIdAsync(int id);
        Task<BuildingAdmin> CreateAsync(BuildingAdmin buildingAdminModel);
        Task<BuildingAdmin?> UpdateAsync(int id, UpdateBuildingAdminRequestDto buildingAdminDto);
        Task<BuildingAdmin?> DeleteAsync(int id);
    }
}