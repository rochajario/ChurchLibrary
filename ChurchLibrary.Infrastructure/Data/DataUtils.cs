using ChurchLibrary.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchLibrary.Infrastructure.Data
{
    public static class DataUtils
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            return services.AddDbContext<ChurchLibraryDbContext>(options => options.UseSqlite(connectionString, x =>
            {
                x.MigrationsAssembly("ChurchLibrary.Web");
            }));
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(UserType.Admin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserType.Admin.ToString()));
            }

            if (!await roleManager.RoleExistsAsync(UserType.Member.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserType.Member.ToString()));
            }
        }
    }
}
