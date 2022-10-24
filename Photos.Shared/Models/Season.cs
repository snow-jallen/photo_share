namespace Photos.Shared.Models;

public class Season
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public DateOnly EndsOn { get; set; }
    public List<Event> Events { get; set; } = new();
    public List<AccessCode> AccessCodes { get; set; } = new();
    public List<SingleUseLink> SingleUseLinks { get; set; } = new();
    public List<Authorization> Authorizations { get; set; } = new();
}
