using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.BuildingAdmin;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BuildingAdminRepository : IBuildingAdminRepository
    {
        private readonly ApplicationDBContext _context;
        public BuildingAdminRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<BuildingAdmin> CreateAsync(BuildingAdmin buildingAdminModel)
        {
            await _context.BuildingAdmins.AddAsync(buildingAdminModel);
            await _context.SaveChangesAsync();
            return buildingAdminModel;
        }

        public async Task<BuildingAdmin?> DeleteAsync(int id)
        {
            var buildingAdminModel = await _context.BuildingAdmins.FirstOrDefaultAsync(x => x.Id == id);
            
            if (buildingAdminModel == null)
            {
                return null;
            }
            
            _context.BuildingAdmins.Remove(buildingAdminModel);
            await _context.SaveChangesAsync();
            return buildingAdminModel;
        }

        public async Task<List<BuildingAdmin>> GetAllAsync()
        {
            return await _context.BuildingAdmins.ToListAsync();
        }

        public async Task<BuildingAdmin?> GetByIdAsync(int id)
        {
            return await _context.BuildingAdmins.FindAsync(id);
        }

        public async Task<BuildingAdmin?> UpdateAsync(int id, UpdateBuildingAdminRequestDto buildingAdminDto)
        {
            var existingBuildingAdmin = await _context.BuildingAdmins.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBuildingAdmin == null)
            {
                return null;
            }

            existingBuildingAdmin.BuildingName = buildingAdminDto.BuildingName;
            existingBuildingAdmin.Name = buildingAdminDto.Name;
            existingBuildingAdmin.Surname = buildingAdminDto.Surname;

            await _context.SaveChangesAsync();

            return existingBuildingAdmin;            
        }
    }
}