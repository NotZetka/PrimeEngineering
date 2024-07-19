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

            Manager Manager = null;

            if (await _userManager.FindByNameAsync("Manager1") == null)
            {
                Manager = new()
                {
                    UserName = "Manager1",
                    Email = "Manager@123.pl"
                };
                var result = await _userManager.CreateAsync(Manager, "Test.123");
                await _userManager.AddToRoleAsync(Manager, "Manager");
            }

            Employee employee = null;
            if (await _userManager.FindByNameAsync("Employee1") == null)
            {
                employee = new()
                {
                    Manager = Manager,
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
                    Manager = Manager,
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
                employee.Tasks.Add(new()
                {
                    AuthorId = employee.Id,
                    Header = "Task2",
                    Description = "Task2 description",
                    Priority = Priority.Medium,
                    Employees = new List<Employee>() { employee2 },
                    DateCreated = DateTime.Now,
                    DateDeadline = DateTime.Now.AddDays(40),
                });
                employee.Tasks.Add(new()
                {
                    AuthorId = employee.Id,
                    Header = "Task3",
                    Description = "Task3 description",
                    Priority = Priority.Medium,
                    Employees = new List<Employee>() { employee2 },
                    DateCreated = DateTime.Now,
                    DateDeadline = DateTime.Now.AddDays(41),
                });
                employee.Tasks.Add(new()
                {
                    AuthorId = employee.Id,
                    Header = "Task4",
                    Description = "Task4 description",
                    Priority = Priority.Medium,
                    Employees = new List<Employee>() { employee2 },
                    DateCreated = DateTime.Now,
                    DateDeadline = DateTime.Now.AddDays(10),
                });
                employee2.Tasks.Add(new()
                {
                    AuthorId = employee2.Id,
                    Header = "Task5",
                    Description = "Task5 description",
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
