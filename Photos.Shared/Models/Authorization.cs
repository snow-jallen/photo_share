namespace Photos.Shared.Models;

public class Authorization
{
    public long Id { get; set; }
    public long PersonId { get; set; }
    public Person? Person { get; set; }
    public long SeasonId { get; set; }
    public Season? Season { get; set; }
}
