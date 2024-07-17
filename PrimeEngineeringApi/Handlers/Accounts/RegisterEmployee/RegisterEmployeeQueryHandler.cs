using MediatR;
using Microsoft.AspNetCore.Identity;
using PrimeEngineeringApi.Data;
using PrimeEngineeringApi.Data.Repositories.Accounts;
using PrimeEngineeringApi.Services;
using PrimeEngineeringApi.Utilities.Exceptions;

namespace PrimeEngineeringApi.Handlers.Accounts.RegisterEmployee
{
    public class RegisterEmployeeQueryHandler : IRequestHandler<RegisterEmployeeQuery, RegisterEmployeeQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IAccountsRepository _accountsRepository;

        public RegisterEmployeeQueryHandler(UserManager<AppUser> userManager, IUserService userService, IAccountsRepository accountsRepository)
        {
            _userManager = userManager;
            _userService = userService;
            _accountsRepository = accountsRepository;
        }
        public async Task<RegisterEmployeeQueryResponse> Handle(RegisterEmployeeQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            var menager = await _accountsRepository.GetMenagerByIdAsync(userId);
            if (menager == null) throw new NotFoundException($"Menager with id: {userId} han not been found");

            var employee = new Employee()
            {
                Menager = menager,
                Email = request.Email,
                UserName = request.UserName,
            };

            var result = await _userManager.CreateAsync(employee, request.Password);

            if (!result.Succeeded) throw new IdentityException(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(employee, "Employee");

            if (!roleResult.Succeeded) throw new IdentityException(roleResult.Errors);

            return new();
        }
    }
}
