namespace Photos.Shared.Models;

public class Person
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Authorization> Authorizations { get; set; } = new();
    public List<SingleUseLink> SingleUseLinks { get; set; } = new();
    public List<PrintRequest> PrintRequests { get; set; } = new();
}
