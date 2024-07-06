namespace api.Models
{
    public class BuildingAdmin
    {
        public int Id { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}