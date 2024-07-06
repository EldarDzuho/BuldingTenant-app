using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Dtos.BuildingAdmin;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/BuildingAdmin")]
    [ApiController]
    public class BuildingAdminController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public BuildingAdminController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
         [Route("")]

        public async Task<IActionResult> GetAll()
        {
            var BuildingAdmins = await _context.BuildingAdmins.ToListAsync();

            var buildingAdminDto = BuildingAdmins.Select(s => s.ToBuildingAdminDto());                  

            return Ok(BuildingAdmins);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var BuildingAdmin = await _context.BuildingAdmins.FindAsync(id);

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
            await _context.BuildingAdmins.AddAsync(buildingAdminModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = buildingAdminModel.Id}, buildingAdminModel.ToBuildingAdminDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBuildingAdminRequestDto updateDto)
        {
            var buildingAdminModel = await _context.BuildingAdmins.FirstOrDefaultAsync(x => x.Id == id);

            if(buildingAdminModel == null)
            {
                return NotFound();
            }

                buildingAdminModel.BuildingName = updateDto.BuildingName;
                buildingAdminModel.Name = updateDto.Name;
                buildingAdminModel.Surname = updateDto.Surname;

                await _context.SaveChangesAsync();

                return Ok(buildingAdminModel.ToBuildingAdminDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var buildingAdminModel = await _context.BuildingAdmins.FirstOrDefaultAsync(x => x.Id == id);

            if (buildingAdminModel == null)
            {
                return NotFound();
            }            

            _context.BuildingAdmins.Remove(buildingAdminModel);
            
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}