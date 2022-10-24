namespace Photos.Shared.Models;

public class Organization
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }
    public string? PrimaryColor { get; set; }
    public string? LogoUrl { get; set; }
    public List<Team> Teams { get; set; } = new();
}
