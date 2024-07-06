namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? BuildingTenantId { get; set; }
        public BuildingTenant? BuildingTenant { get; set; }
        public int? BuildingAdminId { get; set; }
        public BuildingAdmin? BuildingAdmin { get; set; }

    }
}