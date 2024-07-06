using api.Data;
using api.Dtos;
using api.Dtos.BuildingTenant;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/BuildingTenant")]
    [ApiController]
    public class BuildingTenantController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBuildingTenantRepository _buildingTenantRepo;
        public BuildingTenantController(ApplicationDBContext context, IBuildingTenantRepository buildingTenantRepo)
        {
            _buildingTenantRepo = buildingTenantRepo;
            _context = context;
        }

        [HttpGet]
         [Route("")]

        public async Task<IActionResult> GetAll()
        {
            var BuildingTenants = await _buildingTenantRepo.GetAllAsync(); 

            var buildingTenantDto = BuildingTenants.Select(s => s.ToBuildingTenantDto());

            return Ok(BuildingTenants);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var BuildingTenant = await _buildingTenantRepo.GetByIdAsync(id);

            if (BuildingTenant == null)
            {
                return NotFound();
            }
            return Ok(BuildingTenant);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateBuildingTenantRequestDto buildingTenantDto)
        {
            var buildingTenantModel = buildingTenantDto.ToBuildingTenantFromCreateDto();
            await _buildingTenantRepo.CreateAsync(buildingTenantModel);
            return CreatedAtAction(nameof(GetById), new {id = buildingTenantModel.Id}, buildingTenantModel.ToBuildingTenantDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBuildingTenantRequestDto updateDto)
        {
            var buildingTenantModel = await _buildingTenantRepo.UpdateAsync(id, updateDto);

            if(buildingTenantModel == null)
            {
                return NotFound();
            }

                return Ok(buildingTenantModel.ToBuildingTenantDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var buildingTenantModel = await _buildingTenantRepo.DeleteAsync(id);

            if (buildingTenantModel == null)
            {
                return NotFound();
            }

            return NoContent();

        }


    }
}