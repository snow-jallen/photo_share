namespace Photos.Shared;

public class Category
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public List<Organization> Organizations { get; set; }
}
