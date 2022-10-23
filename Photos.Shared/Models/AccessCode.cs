namespace Photos.Shared.Models;

public class AccessCode
{
    public long Id { get; set; }
    public long SeasonId { get; set; }
    public Season Season { get; set; }
    public string Code { get; set; }
    public DateTime? Deactivated { get; set; }
}
