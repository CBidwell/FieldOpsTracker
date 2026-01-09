namespace Backend.Data.Entities
{
    public class FieldReport
    {
        public Guid Id { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public DateTime CreatedUtc { get; set; }
    }
}
