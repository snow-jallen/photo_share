using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Photos.Web;
using Photos.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var databaseName = builder.Configuration["Database"] ?? "photos.db";
builder.Services.AddDbContext<PhotoContext>(options =>
    options.UseSqlite($"data source={databaseName}"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PhotoContext>();
builder.Services.AddRazorPages();
builder.Services.AddHostedService<DefaultUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

namespace Photos.Web
{
    public static class Strings
    {
        public const string AdminRole = "admins";
    }
}