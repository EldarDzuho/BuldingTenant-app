using api.Data;
using api.Dtos.BuildingTenant;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BuildingTenantRepository : IBuildingTenantRepository
    {
        private readonly ApplicationDBContext _context;
        public BuildingTenantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<BuildingTenant> CreateAsync(BuildingTenant buildingTenantModel)
        {
            await _context.BuildingTenants.AddAsync(buildingTenantModel);
            await _context.SaveChangesAsync();
            return buildingTenantModel;
        }

        public async Task<BuildingTenant?> DeleteAsync(int id)
        {
            var buildingTenantModel = await _context.BuildingTenants.FirstOrDefaultAsync(x => x.Id == id);

            if(buildingTenantModel == null)
            {
                return null;
            }

            _context.BuildingTenants.Remove(buildingTenantModel);
            await _context.SaveChangesAsync();
            return buildingTenantModel;
        }

        public async Task<List<BuildingTenant>> GetAllAsync()
        {

            return await _context.BuildingTenants.ToListAsync();

        }

        public async Task<BuildingTenant?> GetByIdAsync(int id)
        {
            return await _context.BuildingTenants.FindAsync(id);
        }

        public async Task<BuildingTenant?> UpdateAsync(int id, UpdateBuildingTenantRequestDto buildingTenantDto)
        {
            var existingBuldingTenant = await _context.BuildingTenants.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBuldingTenant == null)
            {
                return null;
            }

                existingBuldingTenant.BuildingName = buildingTenantDto.BuildingName;
                existingBuldingTenant.ApartmentNumber = buildingTenantDto.ApartmentNumber;
                existingBuldingTenant.Name = buildingTenantDto.Name;
                existingBuldingTenant.SurName = buildingTenantDto.SurName;
                existingBuldingTenant.ApartmentRenting = buildingTenantDto.ApartmentRenting;
                existingBuldingTenant.ApartmentSale = buildingTenantDto.ApartmentSale;
                existingBuldingTenant.GarageRenting = buildingTenantDto.GarageRenting;
                existingBuldingTenant.GarageSale = buildingTenantDto.GarageSale;
                existingBuldingTenant.ApartmentDescription = buildingTenantDto.ApartmentDescription;      

                await _context.SaveChangesAsync();

                return existingBuldingTenant;      
        }
    }
}