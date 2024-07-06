using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.BuildingTenant
{
    public class UpdateBuildingTenantRequestDto
    {
        public string BuildingName { get; set; } = string.Empty;
        public int ApartmentNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public bool ApartmentRenting { get; set; }
        public bool ApartmentSale { get; set; }
        public bool GarageRenting { get; set; }
        public bool GarageSale { get; set; }
        public string ApartmentDescription { get; set; } = string.Empty;
    }
}