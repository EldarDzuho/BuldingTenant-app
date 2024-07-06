using api.Dtos;
using api.Dtos.BuildingTenant;
using api.Models;

namespace api.Mappers
{
    public static class BuildingTenantMappers
    {
        public static BuildingTenantDto ToBuildingTenantDto (this BuildingTenant buildingTenantModel)
        {
            return new BuildingTenantDto
            {
                Id = buildingTenantModel.Id,
                BuildingName = buildingTenantModel.BuildingName,
                ApartmentNumber = buildingTenantModel.ApartmentNumber,
                Name = buildingTenantModel.Name,
                SurName = buildingTenantModel.SurName,
                ApartmentRenting = buildingTenantModel.ApartmentRenting,
                ApartmentSale = buildingTenantModel.ApartmentSale,
                GarageRenting = buildingTenantModel.GarageRenting,
                GarageSale = buildingTenantModel.GarageSale,
                ApartmentDescription = buildingTenantModel.ApartmentDescription
            };
        }

        public static BuildingTenant  ToBuildingTenantFromCreateDto(this CreateBuildingTenantRequestDto buildingTenantDto)
        {
            return new BuildingTenant
            {
                BuildingName = buildingTenantDto.BuildingName,
                ApartmentNumber = buildingTenantDto.ApartmentNumber,
                Name = buildingTenantDto.Name,
                SurName = buildingTenantDto.SurName,
                ApartmentRenting = buildingTenantDto.ApartmentRenting,
                ApartmentSale = buildingTenantDto.ApartmentSale,
                GarageRenting = buildingTenantDto.GarageRenting,
                GarageSale = buildingTenantDto.GarageSale,
                ApartmentDescription = buildingTenantDto.ApartmentDescription
            };
        }

    }
}