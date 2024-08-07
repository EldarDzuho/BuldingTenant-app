using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Dtos.BuildingAdmin;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/BuildingAdmin")]
    [ApiController]
    public class BuildingAdminController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBuildingAdminRepository _buildingAdminRepo;
        public BuildingAdminController(ApplicationDBContext context, IBuildingAdminRepository buildingAdminRepo)
        {
            _buildingAdminRepo = buildingAdminRepo;
            _context = context;
        }

        [HttpGet]
         [Route("")]

        public async Task<IActionResult> GetAll()
        {
            var BuildingAdmins = await _buildingAdminRepo.GetAllAsync();

            var buildingAdminDto = BuildingAdmins.Select(s => s.ToBuildingAdminDto());                  

            return Ok(BuildingAdmins);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var BuildingAdmin = await _buildingAdminRepo.GetByIdAsync(id);

            if (BuildingAdmin == null)
            {
                return NotFound();
            }
            return Ok(BuildingAdmin.ToBuildingAdminDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateBuildingAdminRequestDto buildingAdminDto)
        {
            var buildingAdminModel = buildingAdminDto.ToBuildingAdminFromCreateDto();
            await _buildingAdminRepo.CreateAsync(buildingAdminModel);
            return CreatedAtAction(nameof(GetById), new {id = buildingAdminModel.Id}, buildingAdminModel.ToBuildingAdminDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBuildingAdminRequestDto updateDto)
        {
            var buildingAdminModel = await _buildingAdminRepo.UpdateAsync(id, updateDto);

            if(buildingAdminModel == null)
            {
                return NotFound();
            }

                return Ok(buildingAdminModel.ToBuildingAdminDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var buildingAdminModel = await _buildingAdminRepo.DeleteAsync(id);

            if (buildingAdminModel == null)
            {
                return NotFound();
            }            

            return NoContent();

        }

    }
}