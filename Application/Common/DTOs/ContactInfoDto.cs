namespace Application.Common.DTOs;

public sealed record ContactInfoDto
{
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
}