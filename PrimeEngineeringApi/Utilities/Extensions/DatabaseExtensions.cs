using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrimeEngineeringApi.Data;
using PrimeEngineeringApi.Data.Repositories.Accounts;

namespace PrimeEngineeringApi.Utilities.Extensions
{
    public static class DatabaseExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using DataContext dbContext =
                scope.ServiceProvider.GetRequiredService<DataContext>();

            dbContext.Database.Migrate();
        }

        public static async void AddIdentitiesToDb(this IApplicationBuilder app)
        {
            var roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<AppUserRole>>();
            var roles = new List<AppUserRole>
            {
                new AppUserRole{Name = "Menager"},
                new AppUserRole{Name = "Employee"},
            };

            foreach (var role in roles)
            {
                if (await roleManager.FindByNameAsync(role.Name) == null)
                    await roleManager.CreateAsync(role);
            }
        }

        public static void AddDatabaseWithIdentities(this IServiceCollection services, string connectionstring)
        {
            services.AddDbContext<DataContext>(options =>
                   options.UseSqlServer(connectionstring));
            services.AddIdentityCore<AppUser>()
                .AddRoles<AppUserRole>()
                .AddRoleManager<RoleManager<AppUserRole>>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountsRepository, AccountsRepository>();

            return services;
        }
    }
}
