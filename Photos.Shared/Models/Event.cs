namespace Photos.Shared.Models;

public class Event
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public DateOnly Date { get; set; }
    public string? Location { get; set; }
    public List<Photo> Photos { get; set; } = new();
}
