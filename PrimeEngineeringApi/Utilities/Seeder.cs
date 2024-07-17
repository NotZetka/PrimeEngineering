using Microsoft.AspNetCore.Identity;
using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Utilities
{
    public static class Seeder
    {
        public static async void SeedUsers(this IApplicationBuilder app)
        {
            var _userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            Menager menager = null;

            if (await _userManager.FindByNameAsync("Menager1") == null)
            {
                menager = new()
                {
                    UserName = "Menager1",
                    Email = "Menager@123.pl"
                };
                var result = await _userManager.CreateAsync(menager, "Test.123");
                await _userManager.AddToRoleAsync(menager, "Menager");
            }

            Employee employee = null;
            if (await _userManager.FindByNameAsync("Employee1") == null)
            {
                employee = new()
                {
                    Menager = menager,
                    UserName = "Employee1",
                    Email = "Employee1@123.pl"
                };
                await _userManager.CreateAsync(employee, "Test.123");
                await _userManager.AddToRoleAsync(employee, "Employee");
                {
                };

            }
        }
    }
}
