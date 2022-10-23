using Microsoft.EntityFrameworkCore;
using Photos.Shared.Models;

namespace Photos.Web;

public class PhotoContext : DbContext
{
    public PhotoContext(DbContextOptions<PhotoContext> options)
        : base(options)
    { }

    public DbSet<AccessCode> AccessCodes { get; set; }
    public DbSet<AccessRequest> AccessRequests { get; set; }
    public DbSet<Authorization> Authorizations { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<PrintRequest> PrintRequests { get; set; }
    public DbSet<PrintRequestPhoto> PrintRequestPhotos { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<SingleUseLink> SingleUseLinks { get; set; }
    public DbSet<Team> Teams { get; set; }
}
