namespace Photos.Shared.Models;

public class PrintRequest
{
    public long Id { get; set; }
    public long PersonId { get; set; }
    public Person Person { get; set; }
    public string Comments { get; set; }
    public DateTime RequestedOn { get; set; }
    public DateTime? ClosedOn { get; set; }
    public List<PrintRequestPhoto> Photos { get; set; } = new();
}
