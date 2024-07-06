namespace api.Models
{
    public class BuildingTenant
    {
        public int Id { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public int ApartmentNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public bool ApartmentRenting { get; set; }
        public bool ApartmentSale { get; set; }
        public bool GarageRenting { get; set; }
        public bool GarageSale { get; set; }
        public string ApartmentDescription { get; set; } = string.Empty;
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}