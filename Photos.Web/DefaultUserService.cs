using Microsoft.AspNetCore.Identity;

namespace Photos.Web;

public class DefaultUserService : BackgroundService
{
	private readonly IServiceScopeFactory serviceScopeFactory;
	private readonly ILogger<DefaultUserService> logger;
	private readonly IConfiguration config;

	public DefaultUserService(IServiceScopeFactory serviceScopeFactory, ILogger<DefaultUserService> logger, IConfiguration config)
	{
		this.serviceScopeFactory = serviceScopeFactory;
		this.logger = logger;
		this.config = config;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		using (var scope = serviceScopeFactory.CreateScope())
		{
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			foreach (var adminEmail in config.GetSection("AdminUsers").Get<string[]>())
			{
				var account = await userManager.FindByEmailAsync(adminEmail);
				if (account == null)
				{
					logger.LogInformation("{adminEmail} account not found. Creating.", adminEmail);
					var identityResult = await userManager.CreateAsync(new IdentityUser(adminEmail) { Email = adminEmail }, "def@ultPassword1");
					if (identityResult.Errors.Any())
					{
						logger.LogError("errors creating admin user: ", string.Join(", ", identityResult.Errors));
						throw new Exception("Unable to create default admin user");
					}
					account = await userManager.FindByEmailAsync(adminEmail);
				}

				if (await roleManager.RoleExistsAsync(Strings.AdminRole) is false)
				{
					logger.LogInformation("admins role does not exist.  Creating.");
					await roleManager.CreateAsync(new IdentityRole(Strings.AdminRole));
				}

				if (await userManager.IsInRoleAsync(account, Strings.AdminRole) is false)
				{
					logger.LogInformation("{adminEmail} account not in admins group.  Adding.", adminEmail);
					await userManager.AddToRoleAsync(account, Strings.AdminRole);
				}
			}
		}
	}
}