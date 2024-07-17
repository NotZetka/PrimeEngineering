using Microsoft.AspNetCore.Identity;

namespace PrimeEngineeringApi.Utilities.Exceptions
{
    public class IdentityException : Exception
    {
        public IdentityException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
