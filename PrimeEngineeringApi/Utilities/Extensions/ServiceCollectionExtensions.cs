using FluentValidation;
using MediatR;
using PrimeEngineeringApi.Handlers.Accounts.Login;
using PrimeEngineeringApi.Handlers.Accounts.RegisterEmployee;
using PrimeEngineeringApi.Handlers.Employees.AddContributor;
using PrimeEngineeringApi.Handlers.Employees.CreateTask;
using PrimeEngineeringApi.Handlers.Employees.EditTask;
using PrimeEngineeringApi.Handlers.Employees.GetNoContributorsforTask;
using PrimeEngineeringApi.Handlers.Employees.MarkFinished;
using PrimeEngineeringApi.Handlers.Manager.GetEmployeeStatistics;
using PrimeEngineeringApi.Handlers.Manager.GetEmployeeTasks;
using PrimeEngineeringApi.Middleware;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidatiors(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient<IValidator<LoginQuery>, LoginQueryValidator>();
            services.AddTransient<IValidator<RegisterEmployeeQuery>, RegisterEmployeeQueryValidator>();
            services.AddTransient<IValidator<AddContributorQuery>, AddContributorQueryValidator>();
            services.AddTransient<IValidator<CreateTaskQuery>, CreateTaskQueryvalidator>();
            services.AddTransient<IValidator<EditTaskQuery>, EditTaskQueryValidator>();
            services.AddTransient<IValidator<MarkFinishedQuery>, MarkFinishedQueryValidator>();
            services.AddTransient<IValidator<GetEmployeeStatisticsQuery>, GetEmployeeStatisticsQueryValidator>();
            services.AddTransient<IValidator<GetEmployeeTasksQuery>, GetEmployeeTasksQueryValidator>();
            services.AddTransient<IValidator<GetNoContributorsforTaskQuery>, GetNoContributorsforTaskQueryValidator>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
