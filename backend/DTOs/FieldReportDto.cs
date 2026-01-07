namespace Backend.DTOs
{
    public record FieldReportDto(
        Guid Id,
        string SiteName,
        string Summary,
        DateTime CreatedUtc
    );

}
