using Moongazing.OrionGuard.Core;
using Moongazing.OrionGuard.Demo.Models;
using Moongazing.OrionGuard.Profiles;

namespace Moongazing.OrionGuard.Demo.Services;

public class RegistrationService
{
    public void Register(UserInput input)
    {
        // Fluent Validation
        Guard.For(input.Email, nameof(input.Email)).NotNull().NotEmpty().Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        GuardProfiles.Password(input.Password, nameof(input.Password));

        // Profile Registry (custom demo)
        GuardProfileRegistry.Execute("SafeUsername", input.Username, nameof(input.Username));
    }
}
