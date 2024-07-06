using api.Dtos.BuildingAdmin;
using api.Models;

namespace api.Mappers
{
    public static class BuildingAdminMappers
    {
        public static BuildingAdminDto ToBuildingAdminDto (this BuildingAdmin buildingAdminModel)
        {
            return new BuildingAdminDto
            {
                Id = buildingAdminModel.Id,
                Name = buildingAdminModel.Name,
                BuildingName = buildingAdminModel.BuildingName,
                Surname = buildingAdminModel.Surname
            };
        }
        public static BuildingAdmin  ToBuildingAdminFromCreateDto(this CreateBuildingAdminRequestDto buildingAdminDto)
        {
            return new BuildingAdmin
            {
                Name = buildingAdminDto.Name,
                BuildingName = buildingAdminDto.BuildingName,
                Surname = buildingAdminDto.Surname
            };
        }
    }
}