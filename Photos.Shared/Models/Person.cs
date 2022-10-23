namespace Photos.Shared.Models;

public class Person
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Authorization> Authorizations { get; set; }
    public List<SingleUseLink> SingleUseLinks { get; set; }
    public List<PrintRequest> PrintRequests { get; set; }
}
