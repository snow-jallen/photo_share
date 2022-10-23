namespace Photos.Shared.Models;

public class SingleUseLink
{
    public long Id { get; set; }
    public string? Code { get; set; }
    public long PersonId { get; set; }
    public Person? Person { get; set; }
    public DateTime IssuedOn { get; set; }
    public DateTime? UsedOn { get; set; }
    public long SeasonId { get; set; }
    public Season? Season { get; set; }
}
