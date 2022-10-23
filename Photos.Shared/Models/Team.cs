namespace Photos.Shared.Models;

public class Team
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }
    public List<Season> Seasons { get; set; }
}
