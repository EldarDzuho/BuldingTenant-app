using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.BuildingAdmin
{
    public class BuildingAdminDto
    { 
        public int Id { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}