using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Utilities
{
    public static class Seeder
    {
        public static async void SeedUsers(this IApplicationBuilder app)
        {
            var _userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var _context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

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

            Employee employee2 = null;
            if (await _userManager.FindByNameAsync("Employee2") == null)
            {
                employee2 = new()
                {
                    Menager = menager,
                    UserName = "Employee2",
                    Email = "Employee2@123.pl"
                };
                await _userManager.CreateAsync(employee2, "Test.123");
                await _userManager.AddToRoleAsync(employee2, "Employee");
                {
                };
            }

            if (_context.Tasks.Count() == 0)
            {
                employee = _context.Employees.Include(x => x.Tasks).FirstOrDefault(x => x.UserName == "Employee1");
                employee2 = _context.Employees.Include(x => x.Tasks).FirstOrDefault(x => x.UserName == "Employee2");

                employee.Tasks.Add(new()
                {
                    AuthorId = employee.Id,
                    Header = "Task1",
                    Description = "Task1 description",
                    Priority = Priority.Medium,
                    Employees = new List<Employee>() { employee2 },
                    DateCreated = DateTime.Now,
                    DateDeadline = DateTime.Now.AddDays(5),
                });
                employee2.Tasks.Add(new()
                {
                    AuthorId = employee2.Id,
                    Header = "Task2",
                    Description = "Task2 description",
                    Priority = Priority.Medium,
                    DateCreated = DateTime.Now.AddDays(-2),
                    DateDeadline = DateTime.Now.AddDays(5),
                    DateFinished = DateTime.Now,
                    Finished = true,
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
