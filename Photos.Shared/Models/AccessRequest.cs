namespace Photos.Shared.Models;

public class AccessRequest
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? DesiredSeason { get; set; }
    public string? Comments { get; set; }
    public DateTime RequestedOn { get; set; }
    public DateTime? AcceptedOn { get; set; }
    public DateTime? DeniedOn { get; set; }
}
