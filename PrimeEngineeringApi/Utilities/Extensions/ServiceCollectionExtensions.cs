using FluentValidation;
using MediatR;
using PrimeEngineeringApi.Handlers.Accounts.Login;
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
